using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class AwsBarGraphControllerTest
    {
        private Mock<IAwsBarGraphService> _mockAwsBarGraphService;
        private AwsBarGraphController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockAwsBarGraphService = new Mock<IAwsBarGraphService>();
            _controller = new AwsBarGraphController(_mockAwsBarGraphService.Object);
        }

        [Test]
        public async Task GetAll_NoData_ReturnsOkWithEmptyList()
        {
            // Arrange
            _mockAwsBarGraphService.Setup(service => service.GetAwsBarGraphDataAsync())
                                   .ReturnsAsync(new List<AwsBarGraphDto>());

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<AwsBarGraphDto>>());
            Assert.That(okResult.Value as IEnumerable<AwsBarGraphDto>, Is.Empty);
        }

        [Test]
        public async Task GetAll_WithData_ReturnsOkWithData()
        {
            // Arrange
            var barGraphData = new List<AwsBarGraphDto>
            {
                new AwsBarGraphDto { ExamStatus = "Passed", ExamDate = new DateTime(2024, 1, 15), DepartmentName = "IT" },
                new AwsBarGraphDto { ExamStatus = "Failed", ExamDate = new DateTime(2024, 2, 20), DepartmentName = "HR" }
            };
            _mockAwsBarGraphService.Setup(service => service.GetAwsBarGraphDataAsync())
                                   .ReturnsAsync(barGraphData);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<AwsBarGraphDto>>());
            Assert.That(okResult.Value, Is.EqualTo(barGraphData));
        }

        [Test]
        public async Task GetFiltered_ValidRequest_ReturnsOkWithFilteredData()
        {
            // Arrange
            var filteredData = new MonthlyExamCompletionDTO
            {
                January = 5,
                February = 8
            };
            _mockAwsBarGraphService.Setup(service => service.GetFilteredExamCompletionDataAsync(2024, 1))
                                   .ReturnsAsync(filteredData);

            // Act
            var result = await _controller.GetFiltered(2024, 1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<MonthlyExamCompletionDTO>());
            Assert.That(okResult.Value, Is.EqualTo(filteredData));
        }

        [Test]
        public async Task GetFiltered_WithNullDepartmentId_ReturnsOkWithFilteredData()
        {
            // Arrange
            var filteredData = new MonthlyExamCompletionDTO
            {
                March = 12,
                April = 7
            };
            _mockAwsBarGraphService.Setup(service => service.GetFilteredExamCompletionDataAsync(2024, null))
                                   .ReturnsAsync(filteredData);

            // Act
            var result = await _controller.GetFiltered(2024, null);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<MonthlyExamCompletionDTO>());
            Assert.That(okResult.Value, Is.EqualTo(filteredData));
        }
    }
}
