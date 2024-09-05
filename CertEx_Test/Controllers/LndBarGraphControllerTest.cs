using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class LndBarGraphControllerTest
    {
        private Mock<ILndBarGraphService> _mockLndBarGraphService;
        private LndBarGraphController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockLndBarGraphService = new Mock<ILndBarGraphService>();
            _controller = new LndBarGraphController(_mockLndBarGraphService.Object);
        }

        [Test]
        public async Task GetLndBarGraphData_NoData_ReturnsOkWithEmptyList()
        {
            // Arrange
            _mockLndBarGraphService.Setup(service => service.GetLndBarGraphDataAsync())
                                   .ReturnsAsync(new List<LndBarGraphDTO>());

            // Act
            var result = await _controller.GetLndBarGraphData();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<LndBarGraphDTO>>());
            Assert.That(okResult.Value as IEnumerable<LndBarGraphDTO>, Is.Empty);
        }

        [Test]
        public async Task GetLndBarGraphData_WithData_ReturnsOkWithData()
        {
            // Arrange
            var barGraphData = new List<LndBarGraphDTO>
            {
                new LndBarGraphDTO { ExamStatus = "Passed", ExamDate = new System.DateTime(2024, 1, 15), DepartmentName = "HR" },
                new LndBarGraphDTO { ExamStatus = "Failed", ExamDate = new System.DateTime(2024, 2, 10), DepartmentName = "Finance" }
            };
            _mockLndBarGraphService.Setup(service => service.GetLndBarGraphDataAsync())
                                   .ReturnsAsync(barGraphData);

            // Act
            var result = await _controller.GetLndBarGraphData();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<LndBarGraphDTO>>());
            Assert.That(okResult.Value, Is.EqualTo(barGraphData));
        }

        [Test]
        public async Task GetFilteredExamCompletionData_ValidRequest_ReturnsOkWithFilteredData()
        {
            // Arrange
            var filteredData = new MonthlyExamCompletionDTO
            {
                January = 5,
                February = 8,
                March = 10,
                April = 0,
                May = 12,
                June = 7,
                July = 14,
                August = 9,
                September = 6,
                October = 11,
                November = 3,
                December = 4
            };
            _mockLndBarGraphService.Setup(service => service.GetFilteredExamCompletionDataAsync(2024, 1, 1))
                                   .ReturnsAsync(filteredData);

            // Act
            var result = await _controller.GetFilteredExamCompletionData(2024, 1, 1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<MonthlyExamCompletionDTO>());
            Assert.That(okResult.Value, Is.EqualTo(filteredData));
        }

        [Test]
        public async Task GetFilteredExamCompletionData_WithNullDepartmentAndProviderId_ReturnsOkWithFilteredData()
        {
            // Arrange
            var filteredData = new MonthlyExamCompletionDTO
            {
                January = 10,
                February = 12,
                March = 15,
                April = 8,
                May = 9,
                June = 13,
                July = 6,
                August = 7,
                September = 5,
                October = 14,
                November = 4,
                December = 3
            };
            _mockLndBarGraphService.Setup(service => service.GetFilteredExamCompletionDataAsync(2024, null, null))
                                   .ReturnsAsync(filteredData);

            // Act
            var result = await _controller.GetFilteredExamCompletionData(2024, null, null);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<MonthlyExamCompletionDTO>());
            Assert.That(okResult.Value, Is.EqualTo(filteredData));
        }

        [Test]
        public async Task GetFilteredExamCompletionData_WithNullProviderId_ReturnsOkWithFilteredData()
        {
            // Arrange
            var filteredData = new MonthlyExamCompletionDTO
            {
                January = 7,
                February = 9,
                March = 12,
                April = 6,
                May = 10,
                June = 11,
                July = 8,
                August = 5,
                September = 7,
                October = 13,
                November = 2,
                December = 1
            };
            _mockLndBarGraphService.Setup(service => service.GetFilteredExamCompletionDataAsync(2024, 1, null))
                                   .ReturnsAsync(filteredData);

            // Act
            var result = await _controller.GetFilteredExamCompletionData(2024, 1, null);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<MonthlyExamCompletionDTO>());
            Assert.That(okResult.Value, Is.EqualTo(filteredData));
        }
    }
}
