using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using NotesAPI.Models;

namespace NotesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private static readonly List<Category> _categories = new List<Category>()
        {
            new Category(){CategoryId = "1", Name = "To do"},
            new Category(){CategoryId = "2", Name = "Doing"},
            new Category(){CategoryId = "3", Name = "Done"}
        };

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns>categories</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categories);
        }

        /// <summary>
        /// Get one category.
        /// </summary>
        /// <response code="200">Success getting one category from the list.</response>
        /// <response code="404">Getting the category failed because of invalid id.</response>
        /// <returns>Returns one category from the list</returns>
        [HttpGet("{id}")]
        public IActionResult GetOne(string id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }

            return Ok(category);
        }

        /// <summary>
        /// Add a new category.
        /// </summary>
        /// <response code="200">Success adding category in list.</response>
        /// <response code="403">Getting the category in the list failed because of duplicated category.</response>
        /// <returns>200 Ok successful</returns>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (_categories.Any(item => item.CategoryId == category.CategoryId || item.Name == category.Name))
            {
                return Forbid("Duplicate category");
            }

            _categories.Add(category);
            return Ok("Successfully added");
        }

        /// <summary>
        /// Delete one category.
        /// </summary>
        /// <response code="200">Success deleting category in list.</response>
        /// <response code="404">Deleting the category failed because the category was not found</response>
        /// <returns>200 Ok successful</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound($"Category with id {id} not found");
            }

            _categories.Remove(category);

            return Ok("Successfully removed");
        }
    }
}
