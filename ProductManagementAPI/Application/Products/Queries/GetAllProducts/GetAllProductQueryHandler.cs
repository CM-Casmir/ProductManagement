using MediatR;
using ProductManagementAPI.Data.UnitOfWork;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDTO>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }
    }
}
