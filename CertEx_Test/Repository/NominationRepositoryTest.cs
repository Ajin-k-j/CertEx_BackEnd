using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using CertExBackend.Model;
using CertExBackend.Repository;
using CertExBackend.Data;

namespace CertEx_Test.Repository
{
    [TestFixture]
    internal class NominationRepositoryTest
    {
        private ApiDbContext _dbContext;
        private NominationRepository _repository;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_" + Guid.NewGuid().ToString())
                .Options;

            _dbContext = new ApiDbContext(options);
            _repository = new NominationRepository(_dbContext);
        }

        [Test]
        public async Task GetAllNominationsAsync_ReturnsAllNominations()
        {
            // Arrange
            var nominations = new List<Nomination>
    {
        new Nomination { Id = 1, MotivationDescription = "Motivation1", PlannedExamMonth = "2024-01" },
        new Nomination { Id = 2, MotivationDescription = "Motivation2", PlannedExamMonth = "2024-02" }
    };

            // Ensure nominations are added to the in-memory database before querying
            await _dbContext.Nominations.AddRangeAsync(nominations);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllNominationsAsync();

            // Assert
            Assert.That(result, Is.Not.Null);  // Ensure result is not null
            Assert.That(result.Count(), Is.EqualTo(nominations.Count));  // Ensure the count is correct
            Assert.That(result, Has.Exactly(1).Matches<Nomination>(n => n.Id == 1)); // Check for specific data
            Assert.That(result, Has.Exactly(1).Matches<Nomination>(n => n.Id == 2)); // Check for specific data
        }


        [Test]
        public async Task GetNominationByIdAsync_ReturnsCorrectNomination()
        {
            // Arrange
            var nomination = new Nomination { Id = 1, MotivationDescription = "Motivation1", PlannedExamMonth = "2024-01" };
            await _dbContext.Nominations.AddAsync(nomination);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _repository.GetNominationByIdAsync(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(nomination.Id));
            Assert.That(result.MotivationDescription, Is.EqualTo("Motivation1"));
            Assert.That(result.PlannedExamMonth, Is.EqualTo("2024-01"));
        }

        [Test]
        public async Task AddNominationAsync_AddsNomination()
        {
            // Arrange
            var nomination = new Nomination { Id = 1, MotivationDescription = "Motivation1", PlannedExamMonth = "2024-01" };

            // Act
            await _repository.AddNominationAsync(nomination);

            // Assert
            var result = await _dbContext.Nominations.FindAsync(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(nomination.Id));
            Assert.That(result.MotivationDescription, Is.EqualTo("Motivation1"));
            Assert.That(result.PlannedExamMonth, Is.EqualTo("2024-01"));
        }

        [Test]
        public async Task UpdateNominationAsync_UpdatesExistingNomination()
        {
            // Arrange
            var nomination = new Nomination { Id = 1, MotivationDescription = "Motivation1", PlannedExamMonth = "2024-01" };
            await _dbContext.Nominations.AddAsync(nomination);
            await _dbContext.SaveChangesAsync();

            var updatedNomination = new Nomination { Id = 1, MotivationDescription = "Updated Motivation", PlannedExamMonth = "2024-02" };

            // Act
            await _repository.UpdateNominationAsync(updatedNomination);

            // Assert
            var result = await _dbContext.Nominations.FindAsync(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.MotivationDescription, Is.EqualTo("Updated Motivation"));
            Assert.That(result.PlannedExamMonth, Is.EqualTo("2024-02"));
        }

        [Test]
        public async Task DeleteNominationAsync_DeletesExistingNomination()
        {
            // Arrange
            var nomination = new Nomination { Id = 1, MotivationDescription = "Motivation1", PlannedExamMonth = "2024-01" };
            await _dbContext.Nominations.AddAsync(nomination);
            await _dbContext.SaveChangesAsync();

            // Act
            await _repository.DeleteNominationAsync(1);

            // Assert
            var result = await _dbContext.Nominations.FindAsync(1);
            Assert.That(result, Is.Null);
        }
    }
}
