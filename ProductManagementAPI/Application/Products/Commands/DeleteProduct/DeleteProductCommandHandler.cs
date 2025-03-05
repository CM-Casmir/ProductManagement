using MediatR;
using ProductManagementAPI.Data.UnitOfWork;

namespace ProductManagementAPI.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            // Fetch product by ID
            var product = await _unitOfWork.Products.GetByIdAsync(command.Id);
            if (product == null)
            {
                // Product not found; return without performing any action
                return Unit.Value;
            }

            // Delete product
            _unitOfWork.Products.Delete(product);

            // Save changes to database
            await _unitOfWork.CompleteAsync();

            return Unit.Value; // Indicate successful completion
        }
    }
}
