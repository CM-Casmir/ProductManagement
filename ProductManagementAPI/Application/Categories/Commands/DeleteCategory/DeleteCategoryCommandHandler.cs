using MediatR;
using ProductManagementAPI.Data.UnitOfWork;

namespace ProductManagementAPI.Application.Categories.Commands.DeleteCategory
{

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(command.Id);
            if (category == null) return Unit.Value;

            _unitOfWork.Categories.Delete(category);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
