using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Category.Api.Models;
using Category.Api.Services;

namespace Category.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

       [HttpGet]
public async Task<IActionResult> Get()
{
    try
    {
        var data = await _service.GetAllAsync();
        return Ok(data);
    }
    catch
    {
        return StatusCode(500, "Internal server error");
    }
}

[HttpPost]
public async Task<IActionResult> Post(CategoryModel category)
{
    if (category == null)
        return BadRequest();

    await _service.AddAsync(category);
    return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
}
}
}
