using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using CertExBackend.Controllers;
using CertExBackend.Services.IServices;
using CertExBackend.DTOs;
using NUnit.Framework.Legacy;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class DepartmentNominationsControllerTests
    {
        private Mock<IDepartmentNominationService>? _serviceMock;
        private DepartmentNominationsController? _controller;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IDepartmentNominationService>();
            _controller = new DepartmentNominationsController(_serviceMock.Object);
        }

        [Test]
        public async Task GetNominations_ReturnsOkResult_WithListOfNominations()
        {
            // Arrange
            int departmentId = 1;
            var nominations = new List<DepartmentNominationDto>
            {
                new DepartmentNominationDto { NominationId = 1, EmployeeName = "John Doe", Email = "john.doe@example.com" },
                new DepartmentNominationDto { NominationId = 2, EmployeeName = "Jane Doe", Email = "jane.doe@example.com" }
            };
            _serviceMock.Setup(s => s.GetNominationsByDepartmentAsync(departmentId))
                        .ReturnsAsync(nominations);

            // Act
            var result = await _controller.GetNominations(departmentId);

            // Assert
            ClassicAssert.IsNotNull(result, "The result should not be null.");
            var okResult = result as OkObjectResult;
            ClassicAssert.IsNotNull(okResult, "The result should be an OkObjectResult.");
            ClassicAssert.AreEqual(200, okResult.StatusCode, "The status code should be 200.");
            ClassicAssert.IsNotNull(okResult.Value, "The value in OkObjectResult should not be null.");
            ClassicAssert.IsInstanceOf<IEnumerable<DepartmentNominationDto>>(okResult.Value, "The value should be of type IEnumerable<DepartmentNominationDto>.");
        }

        
    }
}
