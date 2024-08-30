using NUnit.Framework;
using Moq;
using CertExBackend.DTOs;
using CertExBackend.Repositories;
using CertExBackend.Services;
using System.Threading.Tasks;

namespace YourProject.Tests
{
    [TestFixture]
    public class DepartmentStatsServiceTests
    {
        private Mock<IDepartmentStatsRepository> _mockDepartmentStatsRepository;
        private IDepartmentStatsService _departmentStatsService;

        [SetUp]
        public void SetUp()
        {
            // Initialize the mock repository
            _mockDepartmentStatsRepository = new Mock<IDepartmentStatsRepository>();

            // Initialize the service with the mock repository
            _departmentStatsService = new DepartmentStatsService(_mockDepartmentStatsRepository.Object, null); // Mock IMapper if necessary
        }

        [Test]
        public async Task GetDepartmentStatsAsync_ShouldReturnCorrectData()
        {
            // Arrange
            var expectedDepartmentStats = new DepartmentStatsDto
            {
                Department = "DU 6",
                Employees = 30,
                Certifications = 20
            };

            _mockDepartmentStatsRepository
                .Setup(repo => repo.GetDepartmentStatsAsync())
                .ReturnsAsync(expectedDepartmentStats);

            // Act
            var result = await _departmentStatsService.GetDepartmentStatsAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedDepartmentStats.Department, result.Department);
            Assert.AreEqual(expectedDepartmentStats.Employees, result.Employees);
            Assert.AreEqual(expectedDepartmentStats.Certifications, result.Certifications);
        }
    }
}
