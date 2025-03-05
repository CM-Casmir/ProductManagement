using MediatR;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
