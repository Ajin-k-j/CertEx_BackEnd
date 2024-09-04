using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class LDNominationControllerTests
    {
        private Mock<ILDNominationService> _mockService;
        private LDNominationController _controller;

        [SetUp]
        public void Setup()
        {
            _mockService = new Mock<ILDNominationService>();
            _controller = new LDNominationController(_mockService.Object);
        }

        [Test]
        public async Task GetNomination_ReturnsOkResult_WithNomination()
        {
            // Arrange
            int nominationId = 1;
            var nomination = new LDNominationDto
            {
                NominationId = 1,
                EmployeeId = 123,
                EmployeeName = "John Doe",
                Email = "john.doe@example.com",
                Department = "IT",
                Provider = "CertProvider",
                CertificationName = "Certification",
                Criticality = "High",
                NominationDate = DateTime.UtcNow,
                MotivationDescription = "Motivated to excel.",
                ManagerRecommendation = "Recommended",
                ManagerRemarks = "Good to go",
                IsDepartmentApproved = true,
                IsLndApproved = true,
                ExamDate = DateTime.UtcNow.AddMonths(1),
                ExamStatus = "Scheduled",
                UploadCertificateStatus = "Pending",
                SkillMatrixStatus = "Completed",
                ReimbursementStatus = "Approved",
                NominationStatus = "Approved",
                FinancialYear = "2024",
                CostOfCertification = 1000,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "system",
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = "system"
            };

            _mockService.Setup(s => s.GetNominationByIdAsync(nominationId))
                        .ReturnsAsync(nomination);

            // Act
            var result = await _controller.GetNomination(nominationId);

            // Assert
            ClassicAssert.IsNotNull(result, "The result should not be null.");
            var actionResult = result as ActionResult<LDNominationDto>;
            ClassicAssert.IsNotNull(actionResult, "The result should be an ActionResult<LDNominationDto>.");
            var okResult = actionResult.Result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult, "The result should be an OkObjectResult.");
            ClassicAssert.AreEqual(200, okResult.StatusCode, "The status code should be 200.");
            ClassicAssert.IsNotNull(okResult.Value, "The value in OkObjectResult should not be null.");
            ClassicAssert.AreEqual(nomination, okResult.Value, "The returned nomination should match the expected nomination.");
        }

        [Test]
        public async Task GetNomination_ReturnsNotFound_WhenNominationDoesNotExist()
        {
            // Arrange
            int nominationId = 999;
            _mockService.Setup(s => s.GetNominationByIdAsync(nominationId))
                        .ReturnsAsync((LDNominationDto)null);

            // Act
            var result = await _controller.GetNomination(nominationId);

            // Assert
            ClassicAssert.IsNotNull(result, "The result should not be null.");
            var actionResult = result as ActionResult<LDNominationDto>;
            ClassicAssert.IsNotNull(actionResult, "The result should be an ActionResult<LDNominationDto>.");
            var notFoundResult = actionResult.Result as NotFoundResult;
            ClassicAssert.IsNotNull(notFoundResult, "The result should be a NotFoundResult.");
            ClassicAssert.AreEqual(404, notFoundResult.StatusCode, "The status code should be 404.");
        }

        [Test]
        public async Task GetNomination_ReturnsInternalServerError_OnException()
        {
            // Arrange
            int nominationId = 1;
            _mockService.Setup(s => s.GetNominationByIdAsync(nominationId))
                        .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.GetNomination(nominationId);

            // Assert
            ClassicAssert.IsNotNull(result, "The result should not be null.");
            var actionResult = result as ActionResult<LDNominationDto>;
            ClassicAssert.IsNotNull(actionResult, "The result should be an ActionResult<LDNominationDto>.");
            var statusCodeResult = actionResult.Result as ObjectResult;
            ClassicAssert.IsNotNull(statusCodeResult, "The result should be an ObjectResult.");
            ClassicAssert.AreEqual(500, statusCodeResult.StatusCode, "The status code should be 500.");
            ClassicAssert.AreEqual("Internal server error: Database error", statusCodeResult.Value, "The error message should match.");
        }

        [Test]
        public async Task GetNominations_ReturnsOkResult_WithListOfNominations()
        {
            // Arrange
            var nominations = new List<LDNominationDto>
            {
                new LDNominationDto
                {
                    NominationId = 1,
                    EmployeeId = 123,
                    EmployeeName = "John Doe",
                    Email = "john.doe@example.com",
                    Department = "IT",
                    Provider = "CertProvider",
                    CertificationName = "Certification",
                    Criticality = "High",
                    NominationDate = DateTime.UtcNow,
                    MotivationDescription = "Motivated to excel."
                },
                new LDNominationDto
                {
                    NominationId = 2,
                    EmployeeId = 124,
                    EmployeeName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Department = "HR",
                    Provider = "CertProvider",
                    CertificationName = "Certification B",
                    Criticality = "Medium",
                    NominationDate = DateTime.UtcNow,
                    MotivationDescription = "Strong candidate."
                }
            };

            _mockService.Setup(s => s.GetAllNominationsAsync())
                        .ReturnsAsync(nominations);

            // Act
            var result = await _controller.GetNominations();

            // Assert
            ClassicAssert.IsNotNull(result, "The result should not be null.");
            var actionResult = result as ActionResult<IEnumerable<LDNominationDto>>;
            ClassicAssert.IsNotNull(actionResult, "The result should be an ActionResult<IEnumerable<LDNominationDto>>.");
            var okResult = actionResult.Result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult, "The result should be an OkObjectResult.");
            ClassicAssert.AreEqual(200, okResult.StatusCode, "The status code should be 200.");
            ClassicAssert.IsNotNull(okResult.Value, "The value in OkObjectResult should not be null.");
            ClassicAssert.IsInstanceOf<IEnumerable<LDNominationDto>>(okResult.Value, "The value should be of type IEnumerable<LDNominationDto>.");
            ClassicAssert.AreEqual(nominations, okResult.Value, "The returned nominations should match the expected list.");
        }

        [Test]
        public async Task GetNominations_ReturnsInternalServerError_OnException()
        {
            // Arrange
            _mockService.Setup(s => s.GetAllNominationsAsync())
                        .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _controller.GetNominations();

            // Assert
            ClassicAssert.IsNotNull(result, "The result should not be null.");
            var actionResult = result as ActionResult<IEnumerable<LDNominationDto>>;
            ClassicAssert.IsNotNull(actionResult, "The result should be an ActionResult<IEnumerable<LDNominationDto>>.");
            var statusCodeResult = actionResult.Result as ObjectResult;
            ClassicAssert.IsNotNull(statusCodeResult, "The result should be an ObjectResult.");
            ClassicAssert.AreEqual(500, statusCodeResult.StatusCode, "The status code should be 500.");
            ClassicAssert.AreEqual("Internal server error: Database error", statusCodeResult.Value, "The error message should match.");
        }
    }
}
