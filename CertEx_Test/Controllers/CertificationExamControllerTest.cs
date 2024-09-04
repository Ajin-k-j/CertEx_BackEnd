using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    internal class CertificationExamControllerTest
    {
        private Mock<ICertificationExamService> _mockCertificationExamService;
        private CertificationExamController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockCertificationExamService = new Mock<ICertificationExamService>();
            _controller = new CertificationExamController(_mockCertificationExamService.Object);
        }

        [Test]
        public async Task AllCertificationExams_NoExams_ReturnsOk()
        {
            // Arrange
            _mockCertificationExamService.Setup(service => service.GetAllCertificationExamsAsync())
                                         .ReturnsAsync(new List<CertificationExamDto>());

            // Act
            var result = await _controller.AllCertificationExams();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<CertificationExamDto>>());
            Assert.That(okResult.Value as IEnumerable<CertificationExamDto>, Is.Empty);
        }

        [Test]
        public async Task AllCertificationExams_WithExams_ReturnsOk()
        {
            // Arrange
            var exams = new List<CertificationExamDto>
            {
                new CertificationExamDto { Id = 1, CertificationName = "Exam1" }
            };
            _mockCertificationExamService.Setup(service => service.GetAllCertificationExamsAsync())
                                         .ReturnsAsync(exams);

            // Act
            var result = await _controller.AllCertificationExams();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<CertificationExamDto>>());
            Assert.That(okResult.Value, Is.EqualTo(exams));
        }

        [Test]
        public async Task GetCertificationExamById_ExamExists_ReturnsOk()
        {
            // Arrange
            var exam = new CertificationExamDto { Id = 1, CertificationName = "Exam1" };
            _mockCertificationExamService.Setup(service => service.GetCertificationExamByIdAsync(1))
                                         .ReturnsAsync(exam);

            // Act
            var result = await _controller.GetCertificationExamById(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<CertificationExamDto>());
            Assert.That(okResult.Value, Is.EqualTo(exam));
        }


        [Test]
        public async Task AddCertificationExam_ValidExam_ReturnsOk()
        {
            // Arrange
            var exam = new CertificationExam { Id = 1, CertificationName = "Exam1" };
            _mockCertificationExamService.Setup(service => service.AddCertificationExamAsync(exam))
                                         .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddCertificationExam(exam);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo("Certification Added"));
        }

  

        [Test]
        public async Task DeleteCertificationExam_ExistingExam_ReturnsNoContent()
        {
            // Arrange
            _mockCertificationExamService.Setup(service => service.GetCertificationExamByIdAsync(1))
                                         .ReturnsAsync(new CertificationExamDto { Id = 1, CertificationName = "Exam1" });
            _mockCertificationExamService.Setup(service => service.DeleteCertificationExamAsync(1))
                                         .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteCertificationExam(1);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        
    }
}
