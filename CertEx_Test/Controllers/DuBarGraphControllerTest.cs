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
    public class DuBarGraphControllerTest
    {
        private Mock<IDuBarGraphService> _mockDuBarGraphService;
        private DuBarGraphController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockDuBarGraphService = new Mock<IDuBarGraphService>();
            _controller = new DuBarGraphController(_mockDuBarGraphService.Object);
        }

        [Test]
        public async Task GetAll_NoData_ReturnsOkWithEmptyList()
        {
            // Arrange
            _mockDuBarGraphService.Setup(service => service.GetDuBarGraphDataAsync())
                                  .ReturnsAsync(new List<DuBarGraphDto>());

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<DuBarGraphDto>>());
            Assert.That(okResult.Value as IEnumerable<DuBarGraphDto>, Is.Empty);
        }

        [Test]
        public async Task GetAll_WithData_ReturnsOkWithData()
        {
            // Arrange
            var barGraphData = new List<DuBarGraphDto>
            {
                new DuBarGraphDto { ExamStatus = "Passed", ExamDate = new System.DateTime(2024, 1, 15), DepartmentName = "DU1" },
                new DuBarGraphDto { ExamStatus = "Failed", ExamDate = new System.DateTime(2024, 2, 10), DepartmentName = "DU2" }
            };
            _mockDuBarGraphService.Setup(service => service.GetDuBarGraphDataAsync())
                                  .ReturnsAsync(barGraphData);

            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<DuBarGraphDto>>());
            Assert.That(okResult.Value, Is.EqualTo(barGraphData));
        }

        [Test]
        public async Task GetFiltered_ValidRequest_ReturnsOkWithFilteredData()
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
            _mockDuBarGraphService.Setup(service => service.GetFilteredExamCompletionDataAsync(2024, 1))
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
        public async Task GetFiltered_WithNullProviderId_ReturnsOkWithFilteredData()
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
            _mockDuBarGraphService.Setup(service => service.GetFilteredExamCompletionDataAsync(2024, null))
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
