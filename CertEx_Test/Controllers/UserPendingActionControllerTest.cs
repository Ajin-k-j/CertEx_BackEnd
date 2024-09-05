using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class UserPendingActionControllerTest
    {
        private Mock<IUserPendingActionService> _mockUserPendingActionService;
        private UserPendingActionController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockUserPendingActionService = new Mock<IUserPendingActionService>();
            _controller = new UserPendingActionController(_mockUserPendingActionService.Object);
        }

        [Test]
        public async Task GetUserPendingActions_ReturnsOkWithData()
        {
            // Arrange
            var pendingActions = new List<UserPendingActionDto>
            {
                new UserPendingActionDto
                {
                    Id = 1,
                    EmployeeId = 101,
                    CertificationId = 201,
                    NominationStatusFromNomination = "Pending",
                    NominationStatusFromCertificationExam = "Approved",
                    CertificationName = "Certification A"
                },
                new UserPendingActionDto
                {
                    Id = 2,
                    EmployeeId = 102,
                    CertificationId = 202,
                    NominationStatusFromNomination = "Completed",
                    NominationStatusFromCertificationExam = "Pending",
                    CertificationName = "Certification B"
                }
            };

            _mockUserPendingActionService.Setup(service => service.GetUserPendingActionsAsync())
                                         .ReturnsAsync(pendingActions);

            // Act
            var result = await _controller.GetUserPendingActions();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<UserPendingActionDto>>());
            Assert.That(okResult.Value as IEnumerable<UserPendingActionDto>, Is.EqualTo(pendingActions));
        }
    }
}
