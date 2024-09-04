using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services;
using CertExBackend.Services.IServices;

namespace CertEx_Test.Services
{
    [TestFixture]
    internal class NominationServiceTest
    {
        private Mock<INominationRepository> _mockNominationRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<ICertificationExamService> _mockCertificationExamService;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private NominationService _service;

        [SetUp]
        public void SetUp()
        {
            _mockNominationRepository = new Mock<INominationRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCertificationExamService = new Mock<ICertificationExamService>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _service = new NominationService(
                _mockNominationRepository.Object,
                null,  // Mock IEmailService
                _mockEmployeeRepository.Object,
                _mockCertificationExamService.Object,
                _mockMapper.Object
            );
        }

        [Test]
        public async Task GetAllNominationsAsync_ReturnsMappedNominations()
        {
            // Arrange
            var nominations = new List<Nomination>
            {
                new Nomination { Id = 1, CertificationId = 1, EmployeeId = 1, PlannedExamMonth = "2024-09" },
                new Nomination { Id = 2, CertificationId = 2, EmployeeId = 2, PlannedExamMonth = "2024-10" }
            };
            var nominationDtos = new List<NominationDto>
            {
                new NominationDto { Id = 1, CertificationId = 1, EmployeeId = 1, PlannedExamMonth = "2024-09" },
                new NominationDto { Id = 2, CertificationId = 2, EmployeeId = 2, PlannedExamMonth = "2024-10" }
            };

            _mockNominationRepository.Setup(repo => repo.GetAllNominationsAsync())
                .ReturnsAsync(nominations);
            _mockMapper.Setup(m => m.Map<IEnumerable<NominationDto>>(nominations))
                .Returns(nominationDtos);

            // Act
            var result = await _service.GetAllNominationsAsync();

            // Assert
            Assert.That(result, Is.EqualTo(nominationDtos));
        }

        [Test]
        public async Task GetNominationByIdAsync_ValidId_ReturnsMappedNomination()
        {
            // Arrange
            var nomination = new Nomination { Id = 1, CertificationId = 1, EmployeeId = 1, PlannedExamMonth = "2024-09" };
            var nominationDto = new NominationDto { Id = 1, CertificationId = 1, EmployeeId = 1, PlannedExamMonth = "2024-09" };

            _mockNominationRepository.Setup(repo => repo.GetNominationByIdAsync(1))
                .ReturnsAsync(nomination);
            _mockMapper.Setup(m => m.Map<NominationDto>(nomination))
                .Returns(nominationDto);

            // Act
            var result = await _service.GetNominationByIdAsync(1);

            // Assert
            Assert.That(result, Is.EqualTo(nominationDto));
        }

        
    }
}
