using Microsoft.AspNetCore.Mvc;
using EcommerceApi.Data;
using EcommerceShared.Models;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EcommerceDbContext _context;

        public CategoryController(EcommerceDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetCategories() => Ok(_context.Categories.ToList());

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, Category updatedCategory)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
