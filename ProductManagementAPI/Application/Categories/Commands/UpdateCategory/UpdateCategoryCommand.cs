using MediatR;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<CategoryDTO>
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
    }
}
