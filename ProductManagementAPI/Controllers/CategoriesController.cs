using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Application.Categories.Commands.CreateCategory;
using ProductManagementAPI.Application.Categories.Commands.DeleteCategory;
using ProductManagementAPI.Application.Categories.Commands.UpdateCategory;
using ProductManagementAPI.Application.Categories.Queries.GetAllCategories;
using ProductManagementAPI.Application.Categories.Queries.GetAllCategoryById;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator; // Mediator instance for handling requests

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator; // Injects the mediator instance
        }

        [HttpGet] 
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetAllCategoriesQuery(); 
            var result = await _mediator.Send(query); // Sends the query to the mediator
            return Ok(result); 
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery { Id = id }; // Creates a new query for getting a category by ID
            var result = await _mediator.Send(query);

            // Returns a NotFound status if the category is not found
            if (result == null) 
                return NotFound(); 
            return Ok(result); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _mediator.Send(command); // Sends the command to the mediator

            return CreatedAtAction(nameof(GetCategoryById), new { id = result.Id }, result); // Returns the created category with a CreatedAtAction status
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.Id) // Checks if the ID in the URL matches the ID in the command
                return BadRequest(); // Returns a BadRequest status if the IDs do not match

            var result = await _mediator.Send(command); // Sends the command to the mediator
            if (result == null)
                return NotFound(); 
            return NoContent(); // Returns a NoContent status if the update is successful
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id }; 
            await _mediator.Send(command); 
            return NoContent(); 
        }
    }
}
