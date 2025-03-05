using MediatR;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Categories.Queries.GetAllCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDTO>
    {
        public int Id { get; set; } // ID of the specific category to retrieve 
    }
}
