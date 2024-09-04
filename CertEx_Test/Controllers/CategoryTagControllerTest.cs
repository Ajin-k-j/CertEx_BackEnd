using CertExBackend.Controllers;
using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertEx_Test.Controllers
{
    [TestFixture]
    internal class CategoryTagControllerTest
    {
        private Mock<ICategoryTagService> _mockCategoryTagService;
        private CategoryTagController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockCategoryTagService = new Mock<ICategoryTagService>();
            _controller = new CategoryTagController(_mockCategoryTagService.Object);
        }

        [Test]
        public async Task AllCategoryTags_NoCategoryTags_ReturnsOk()
        {
            // Arrange
            _mockCategoryTagService.Setup(service => service.GetAllCategoryTagsAsync())
                                   .ReturnsAsync(new List<CategoryTagDto>());

            // Act
            var result = await _controller.AllCategoryTags();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<CategoryTagDto>>());
            Assert.That(okResult.Value as IEnumerable<CategoryTagDto>, Is.Empty);
        }

        [Test]
        public async Task AllCategoryTags_WithCategoryTags_ReturnsOk()
        {
            // Arrange
            var categoryTags = new List<CategoryTagDto>
            {
                new CategoryTagDto { Id = 1, CategoryTagName = "Tag1" }
            };
            _mockCategoryTagService.Setup(service => service.GetAllCategoryTagsAsync())
                                   .ReturnsAsync(categoryTags);

            // Act
            var result = await _controller.AllCategoryTags();

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<IEnumerable<CategoryTagDto>>());
            Assert.That(okResult.Value, Is.EqualTo(categoryTags));
        }

        [Test]
        public async Task GetCategoryTagById_CategoryTagExists_ReturnsOk()
        {
            // Arrange
            var categoryTag = new CategoryTagDto { Id = 1, CategoryTagName = "Tag1" };
            _mockCategoryTagService.Setup(service => service.GetCategoryTagByIdAsync(1))
                                   .ReturnsAsync(categoryTag);

            // Act
            var result = await _controller.GetCategoryTagById(1);

            // Assert
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = result.Result as OkObjectResult;
            Assert.That(okResult.Value, Is.InstanceOf<CategoryTagDto>());
            Assert.That(okResult.Value, Is.EqualTo(categoryTag));
        }

        [Test]
        public async Task AddCategoryTag_ValidCategoryTag_ReturnsOk()
        {
            // Arrange
            var categoryTagDto = new CategoryTagDto { Id = 1, CategoryTagName = "Tag1" };
            _mockCategoryTagService.Setup(service => service.AddCategoryTagAsync(categoryTagDto))
                                   .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddCategoryTag(categoryTagDto);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult.Value, Is.EqualTo("Category tag created successfully."));
        }

        [Test]
        public async Task UpdateCategoryTag_CategoryTagExists_ReturnsNoContent()
        {
            // Arrange
            var categoryTagDto = new CategoryTagDto { Id = 1, CategoryTagName = "Tag1" };
            _mockCategoryTagService.Setup(service => service.GetCategoryTagByIdAsync(1))
                                   .ReturnsAsync(categoryTagDto);
            _mockCategoryTagService.Setup(service => service.UpdateCategoryTagAsync(categoryTagDto))
                                   .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateCategoryTag(categoryTagDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }

        [Test]
        public async Task DeleteCategoryTag_CategoryTagExists_ReturnsNoContent()
        {
            // Arrange
            _mockCategoryTagService.Setup(service => service.GetCategoryTagByIdAsync(1))
                                   .ReturnsAsync(new CategoryTagDto { Id = 1, CategoryTagName = "Tag1" });
            _mockCategoryTagService.Setup(service => service.DeleteCategoryTagAsync(1))
                                   .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteCategoryTag(1);

            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
        }
    }
}
