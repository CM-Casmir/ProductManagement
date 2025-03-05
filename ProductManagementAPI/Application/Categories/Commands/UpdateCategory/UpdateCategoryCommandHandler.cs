using MediatR;
using ProductManagementAPI.Data.UnitOfWork;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDTO> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(command.Id);
            if (category == null) return null;

            category.Name = command.Name;
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.CompleteAsync();

            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }
    }
}
