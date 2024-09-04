using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class DepartmentStatsControllerTests
    {
        private Mock<IDepartmentStatsService>? _mockService;
        private DepartmentStatsController? _controller;

        [SetUp]
        public void SetUp()
        {
            _mockService = new Mock<IDepartmentStatsService>();
            _controller = new DepartmentStatsController(_mockService.Object);
        }

        [Test]
        public async Task GetDepartmentStats_NoStatsFound_ReturnsNotFound()
        {
            // Arrange
            _mockService.Setup(s => s.GetDepartmentStatsAsync(It.IsAny<int>()))
                        .ReturnsAsync((DepartmentStatsDto)null);

            // Act
            var result = await _controller.GetDepartmentStats(1);

            // Assert
            ClassicAssert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetDepartmentStats_StatsFound_ReturnsOkWithStats()
        {
            // Arrange
            var stats = new DepartmentStatsDto
            {
                DepartmentName = "HR",
                EmployeeCount = 25
            };
            _mockService.Setup(s => s.GetDepartmentStatsAsync(It.IsAny<int>()))
                        .ReturnsAsync(stats);

            // Act
            var result = await _controller.GetDepartmentStats(1) as OkObjectResult;

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(stats, result.Value);
        }
    }
}