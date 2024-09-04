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
    internal class CertificationExamServiceTest
    {
        private Mock<ICertificationExamRepository> _mockCertificationExamRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<ICertificationProviderRepository> _mockProviderRepository;
        private Mock<ICertificationTagRepository> _mockCertificationTagRepository;
        private Mock<ICategoryTagRepository> _mockCategoryTagRepository;
        private CertificationExamService _service;

        [SetUp]
        public void SetUp()
        {
            _mockCertificationExamRepository = new Mock<ICertificationExamRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockProviderRepository = new Mock<ICertificationProviderRepository>();
            _mockCertificationTagRepository = new Mock<ICertificationTagRepository>();
            _mockCategoryTagRepository = new Mock<ICategoryTagRepository>();

            _service = new CertificationExamService(
                _mockCertificationExamRepository.Object,
                _mockMapper.Object,
                _mockProviderRepository.Object,
                _mockCertificationTagRepository.Object,
                _mockCategoryTagRepository.Object
            );
        }

        [Test]
        public async Task GetAllCertificationExamsAsync_ReturnsMappedCertificationExamsWithProviderNameAndTags()
        {
            // Arrange
            var certificationExams = new List<CertificationExam>
            {
                new CertificationExam { Id = 1, CertificationProvider = new CertificationProvider { ProviderName = "Provider1" }, CertificationTags = new List<CertificationTag> { new CertificationTag { CategoryTag = new CategoryTag { CategoryTagName = "Tag1" } } } },
                new CertificationExam { Id = 2, CertificationProvider = new CertificationProvider { ProviderName = "Provider2" }, CertificationTags = new List<CertificationTag> { new CertificationTag { CategoryTag = new CategoryTag { CategoryTagName = "Tag2" } } } }
            };
            var certificationExamDtos = new List<CertificationExamDto>
            {
                new CertificationExamDto { Id = 1 },
                new CertificationExamDto { Id = 2 }
            };

            _mockCertificationExamRepository.Setup(repo => repo.GetAllCertificationExamsAsync())
                .ReturnsAsync(certificationExams);
            _mockMapper.Setup(m => m.Map<IEnumerable<CertificationExamDto>>(certificationExams))
                .Returns(certificationExamDtos);

            // Act
            var result = await _service.GetAllCertificationExamsAsync();

            // Assert
            Assert.That(result.Count(), Is.EqualTo(certificationExamDtos.Count));
            Assert.That(result.First().ProviderName, Is.EqualTo("Provider1"));
            Assert.That(result.First().Tags, Contains.Item("Tag1"));
        }


        [Test]
        public async Task AddCertificationExamAsync_ValidCertificationExam_AddsCertificationExam()
        {
            // Arrange
            var certificationExam = new CertificationExam { Id = 1, CertificationName = "Certification 1" };

            // Act
            await _service.AddCertificationExamAsync(certificationExam);

            // Assert
            _mockCertificationExamRepository.Verify(repo => repo.AddCertificationExamAsync(certificationExam), Times.Once);
        }

        [Test]
        public async Task UpdateCertificationExamAsync_ValidCertificationExam_UpdatesCertificationExam()
        {
            // Arrange
            var existingExam = new CertificationExam { Id = 1, CertificationName = "Old Name" };
            var updatedExam = new CertificationExam { Id = 1, CertificationName = "New Name" };

            _mockCertificationExamRepository.Setup(repo => repo.GetCertificationExamByIdAsync(1))
                .ReturnsAsync(existingExam);

            // Act
            await _service.UpdateCertificationExamAsync(updatedExam);

            // Assert
            _mockCertificationExamRepository.Verify(repo => repo.UpdateCertificationExamAsync(It.Is<CertificationExam>(exam => exam.CertificationName == "New Name")), Times.Once);
        }

        [Test]
        public async Task DeleteCertificationExamAsync_ValidId_DeletesCertificationExam()
        {
            // Arrange
            var examId = 1;

            // Act
            await _service.DeleteCertificationExamAsync(examId);

            // Assert
            _mockCertificationExamRepository.Verify(repo => repo.DeleteCertificationExamAsync(examId), Times.Once);
        }
    }
}
