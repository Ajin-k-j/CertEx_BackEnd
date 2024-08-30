using NUnit.Framework;
using Moq;
using CertExBackend.DTOs;
using CertExBackend.Repositories;
using CertExBackend.Services;
using System.Threading.Tasks;

namespace CertExBackend.Tests
{
    [TestFixture]
    public class AwsStatsServiceTests
    {
        private Mock<IAwsStatsRepository> _mockAwsStatsRepository;
        private IAwsStatsService _awsStatsService;

        [SetUp]
        public void SetUp()
        {
            // Initialize the mock repository
            _mockAwsStatsRepository = new Mock<IAwsStatsRepository>();

            // Initialize the service with the mock repository
            _awsStatsService = new AwsStatsService(_mockAwsStatsRepository.Object, null); // You can mock IMapper if necessary
        }

        [Test]
        public async Task GetAwsStatsAsync_ShouldReturnCorrectData()
        {
            // Arrange
            var expectedTotalAwsNominations = 50;
            var expectedPendingNominations = 30;

            _mockAwsStatsRepository
                .Setup(repo => repo.GetTotalAwsNominationsAsync())
                .ReturnsAsync(expectedTotalAwsNominations);

            _mockAwsStatsRepository
                .Setup(repo => repo.GetPendingNominationsAsync())
                .ReturnsAsync(expectedPendingNominations);

            // Act
            var result = await _awsStatsService.GetAwsStatsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedTotalAwsNominations, result.TotalAwsNominations);
            Assert.AreEqual(expectedPendingNominations, result.PendingNominations);
        }
    }
}
