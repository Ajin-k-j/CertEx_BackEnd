using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class AwsStatsControllerTests
    {
        private Mock<IAwsStatsService>? _mockAwsStatsService;
        private AwsStatsController? _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize the mock service
            _mockAwsStatsService = new Mock<IAwsStatsService>();

            // Create an instance of the controller with the mocked service
            _controller = new AwsStatsController(_mockAwsStatsService.Object);
        }

        [Test]
        public async Task GetAwsStats_ReturnsOkResult_WithAwsStatsDto()
        {
            // Arrange
            var expectedDto = new AwsStatsDto
            {
                TotalAwsNominations = 100,
                PendingNominations = 50
            };
            _mockAwsStatsService.Setup(service => service.GetAwsStatsAsync())
                .ReturnsAsync(expectedDto);

            // Act
            var result = await _controller.GetAwsStats();

            // Assert
            Assert.That(result.Result, Is.Not.Null, "Result should not be null");
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>(), "Result should be of type OkObjectResult");

            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult, Is.Not.Null, "OkObjectResult should not be null");
            Assert.That(okResult.Value, Is.InstanceOf<AwsStatsDto>(), "Value should be of type AwsStatsDto");
            Assert.That(okResult.Value, Is.EqualTo(expectedDto), "Returned value should match the expected DTO");
        }


    }
}
