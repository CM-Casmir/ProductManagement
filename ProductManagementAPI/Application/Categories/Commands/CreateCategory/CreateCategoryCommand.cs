using MediatR;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDTO>
    {
        // Name of the new category to create 
        public string Name { get; set; }
    }
}
