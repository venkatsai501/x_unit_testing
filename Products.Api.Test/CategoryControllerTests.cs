using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Category.Api.Controllers;
using Category.Api.Models;
using Category.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Products.Api.Test
{
    public class CategoryControllerTests
    {
        [Fact]
        public async Task Get_ReturnsListOfCategories()
        {
            var mockService = new Mock<ICategoryService>();
            mockService.Setup(s => s.GetAllAsync())
                       .ReturnsAsync(new List<CategoryModel> { new CategoryModel { Id = 1, Name = "Test" } });

            var controller = new CategoryController(mockService.Object);
            var result = await controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var categories = Assert.IsType<List<CategoryModel>>(okResult.Value);
            Assert.Single(categories);
        }

        [Fact]
        public async Task Get_ReturnsEmptyList()
        {
            var mockService = new Mock<ICategoryService>();
            mockService.Setup(s => s.GetAllAsync()).ReturnsAsync(new List<CategoryModel>());

            var controller = new CategoryController(mockService.Object);
            var result = await controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var categories = Assert.IsType<List<CategoryModel>>(okResult.Value);
            Assert.Empty(categories);
        }

        [Fact]
        public async Task Post_ReturnsCreatedResult()
        {
            var mockService = new Mock<ICategoryService>();
            var newCategory = new CategoryModel { Id = 2, Name = "New" };
            mockService.Setup(s => s.AddAsync(newCategory)).Returns(Task.CompletedTask);

            var controller = new CategoryController(mockService.Object);
            var result = await controller.Post(newCategory);

            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<CategoryModel>(createdResult.Value);
            Assert.Equal("New", returnValue.Name);
        }

        [Fact]
        public async Task Post_NullInput_ReturnsBadRequest()
        {
            var mockService = new Mock<ICategoryService>();
            var controller = new CategoryController(mockService.Object);

            var result = await controller.Post(null);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Post_CallsAddAsyncOnce()
        {
            var mockService = new Mock<ICategoryService>();
            var model = new CategoryModel { Id = 3, Name = "MockTest" };

            mockService.Setup(s => s.AddAsync(model)).Returns(Task.CompletedTask).Verifiable();

            var controller = new CategoryController(mockService.Object);
            await controller.Post(model);

            mockService.Verify(s => s.AddAsync(model), Times.Once);
        }
    }
}
