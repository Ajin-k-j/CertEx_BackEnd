using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    internal class NominationControllerTest
    {
        private Mock<INominationService> _mockNominationService;
        private NominationController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockNominationService = new Mock<INominationService>();
            _controller = new NominationController(_mockNominationService.Object, Mock.Of<ILogger<NominationController>>());
        }

        [Test]
        public async Task AllNominations_NoNominations_ReturnsOk()
        {
            // Arrange
            _mockNominationService.Setup(service => service.GetAllNominationsAsync())
                                   .ReturnsAsync(new List<NominationDto>());

            // Act
            var result = await _controller.AllNominations();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<NominationDto>>());
            Assert.That(okResult.Value as IEnumerable<NominationDto>, Is.Empty);
        }


        [Test]
        public async Task AddNomination_ValidNomination_ReturnsOk()
        {
            // Arrange
            var nominationCreateDto = new NominationCreateDto { /* populate with valid data */ };
            _mockNominationService.Setup(service => service.AddNominationAsync(nominationCreateDto))
                                   .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddNomination(nominationCreateDto);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo("Nomination added successfully"));
        }

        [Test]
        public async Task AddNomination_NullNomination_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.AddNomination(null);

            // Assert
            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            var badRequestResult = result as BadRequestObjectResult;
            Assert.That(badRequestResult.Value, Is.EqualTo("Nomination data is required."));
        }

        
    }
}
