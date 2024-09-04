using NUnit.Framework;
using NUnit.Framework.Legacy;  // Ensure you have this for ClassicAssert
using Moq;
using System;
using System.Threading.Tasks;
using CertExBackend.Controllers;
using CertExBackend.Services.IServices;
using CertExBackend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    public class AwsAdminControllerTest
    {
        [Test]
        public async Task SubmitAwsDetails_ValidData_ReturnsOk()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(service => service.UpdateAwsDetailsAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).Returns(Task.CompletedTask);

            var controller = new AwsAdminController(mockEmployeeService.Object);
            var awsDetailsDto = new AwsAdminDetailsDto
            {
                EmployeeId = 1,
                AWSCredentials = "https://aws.amazon.com/certification/certified-solutions-architect-associate/",
                AWSAdminRemarks = "Go to this link and register for the exam"
            };

            // Act
            var result = await controller.SubmitAwsDetails(awsDetailsDto);

            // Assert
            ClassicAssert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            ClassicAssert.AreEqual("AWS credentials setup submitted successfully.", okResult.Value);
        }

        [Test]
        public async Task SubmitAwsDetails_NullData_ReturnsBadRequest()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            var controller = new AwsAdminController(mockEmployeeService.Object);

            // Act
            var result = await controller.SubmitAwsDetails(null);

            // Assert
            ClassicAssert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            ClassicAssert.AreEqual("Invalid data.", badRequestResult.Value);
        }

        [Test]
        public async Task SubmitAwsDetails_ServiceThrowsException_ReturnsInternalServerError()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(service => service.UpdateAwsDetailsAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).ThrowsAsync(new Exception("Service error"));

            var controller = new AwsAdminController(mockEmployeeService.Object);
            var awsDetailsDto = new AwsAdminDetailsDto
            {
                EmployeeId = 1,
                AWSCredentials = "https://aws.amazon.com/certification/certified-solutions-architect-associate/",
                AWSAdminRemarks = "Go to this link and register for the exam"
            };

            // Act
            var result = await controller.SubmitAwsDetails(awsDetailsDto);

            // Assert
            ClassicAssert.IsInstanceOf<ObjectResult>(result);
            var objectResult = result as ObjectResult;
            ClassicAssert.AreEqual(500, objectResult.StatusCode);
            ClassicAssert.AreEqual("Internal server error: Service error", objectResult.Value);
        }
    }
}
