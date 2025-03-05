using MediatR;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDTO>>
    {
    }
}
