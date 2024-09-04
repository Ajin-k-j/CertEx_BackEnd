using NUnit.Framework;
using NUnit.Framework.Legacy;  // Ensure you have this for ClassicAssert
using Moq;
using System;
using System.Threading.Tasks;
using CertExBackend.Controllers;
using CertExBackend.Services.IServices;
using CertExBackend.DTOs;
using Microsoft.AspNetCore.Mvc;
using CertExBackend.DTO;
using CertExBackend.Services;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class AwsNominationControllerTest
    {
        private Mock<IAwsNominationService> _mockAwsNominationService;
        private AwsNominationController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockAwsNominationService = new Mock<IAwsNominationService>();
            _controller = new AwsNominationController(_mockAwsNominationService.Object);
        }

        [Test]
        public async Task GetAllAwsNominations_ValidData_ReturnsOk()
        {
            // Arrange
            var awsNominations = new List<AwsNominationDto>
            {
                new AwsNominationDto { NominationId = 1, EmployeeName = "John Doe", Email = "john.doe@example.com" },
                new AwsNominationDto { NominationId = 2, EmployeeName = "Jane Doe", Email = "jane.doe@example.com" }
            };
            _mockAwsNominationService.Setup(service => service.GetAllAwsNominations()).Returns(awsNominations);

            // Act
            var result = _controller.GetAllAwsNominations().Result;

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual(awsNominations, okResult.Value);
        }




    }
}
