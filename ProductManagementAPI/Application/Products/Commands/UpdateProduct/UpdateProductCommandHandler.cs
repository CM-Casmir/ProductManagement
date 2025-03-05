using MediatR;
using ProductManagementAPI.Data.UnitOfWork;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductDTO> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
            {
                return null;
            }

            product.Name = command.Name;
            product.Price = command.Price;
            product.CategoryId = command.CategoryId;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.CompleteAsync();

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
