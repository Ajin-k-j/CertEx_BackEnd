using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy; // Ensure this namespace is referenced for ClassicAssert
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class EmployeeCertificationControllerTests
    {
        private Mock<IEmployeeCertificationService> _mockService;
        private EmployeeCertificationController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<IEmployeeCertificationService>();
            _controller = new EmployeeCertificationController(_mockService.Object);
        }

        [Test]
        public async Task GetCertifications_ReturnsOkResult_WithCertifications()
        {
            // Arrange
            var employeeId = 1;
            var certifications = new List<EmployeeCertificationDto>
            {
                new EmployeeCertificationDto
                {
                    CertificationId = 1,
                    CertificationName = "Certification A",
                    ProviderName = "Provider A",
                    Level = "Advanced",
                    Category = "Category A",
                    FromDate = new DateTime(2023, 1, 1),
                    ExpiryDate = new DateTime(2024, 1, 1)
                }
            };

            _mockService.Setup(s => s.GetCertificationsByEmployeeIdAsync(employeeId))
                .ReturnsAsync(certifications);

            // Act
            var result = await _controller.GetCertifications(employeeId);

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result, "Expected OkObjectResult");
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual(200, okResult.StatusCode, "Expected HTTP status code 200");
            ClassicAssert.AreEqual(certifications, okResult.Value, "Expected certifications to match");
        }

        
    }
}
