using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using CertExBackend.Controllers;
using CertExBackend.Services;
using CertExBackend.DTO;
using System.Collections.Generic;
using System.Linq;

namespace CertExBackend.Tests
{
    [TestFixture]
    public class AwsNominationControllerTests
    {
        private Mock<IAwsNominationService> _mockService;
        private AwsNominationController _controller;

        [SetUp]
        public void SetUp()
        {
            // Initialize the service mock
            _mockService = new Mock<IAwsNominationService>();

            // Initialize the controller with the mocked service
            _controller = new AwsNominationController(_mockService.Object);
        }

        [Test]
        public void GetAllAwsNominations_ReturnsOkResult_WithListOfAwsNominationDto()
        {
            // Arrange
            var nominations = new List<AwsNominationDto>
            {
                new AwsNominationDto
                {
                    NominationId = 1,
                    EmployeeName = "John Doe",
                    Email = "john.doe@example.com",
                    Department = "Finance",
                    CertificationName = "AWS Certified Solutions Architect",
                    Provider = "AWS",
                    Level = "Expert",
                    Date = new DateTime(2024, 07, 01),
                    Criticality = "High"
                }
            };

            _mockService.Setup(service => service.GetAllAwsNominations()).Returns(nominations);

            // Act
            var result = _controller.GetAllAwsNominations() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var resultValue = result.Value as IEnumerable<AwsNominationDto>;
            Assert.IsNotNull(resultValue);
            Assert.AreEqual(1, resultValue.Count());
            Assert.AreEqual("John Doe", resultValue.First().EmployeeName);
            Assert.AreEqual("Finance", resultValue.First().Department);
        }

        [Test]
        public void GetAllAwsNominations_ReturnsOkResult_WithEmptyList()
        {
            // Arrange
            var nominations = new List<AwsNominationDto>();

            _mockService.Setup(service => service.GetAllAwsNominations()).Returns(nominations);

            // Act
            var result = _controller.GetAllAwsNominations() as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var resultValue = result.Value as IEnumerable<AwsNominationDto>;
            Assert.IsNotNull(resultValue);
            Assert.IsEmpty(resultValue);
        }

        [Test]
        public void GetAllAwsNominations_ReturnsInternalServerError_WhenServiceFails()
        {
            // Arrange
            _mockService.Setup(service => service.GetAllAwsNominations()).Throws(new System.Exception("Service error"));

            // Act
            var result = _controller.GetAllAwsNominations() as ObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
            Assert.AreEqual("Service error", result.Value);
        }
    }
}
