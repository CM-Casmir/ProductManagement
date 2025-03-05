using MediatR;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductDTO>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
