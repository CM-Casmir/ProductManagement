using MediatR;
using ProductManagementAPI.Data.UnitOfWork;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(query.Id);
            if (product == null)
            {
                return null;
            }

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
