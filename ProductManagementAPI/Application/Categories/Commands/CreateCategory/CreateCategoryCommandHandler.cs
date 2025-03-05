using MediatR;
using ProductManagementAPI.Data.UnitOfWork;
using ProductManagementAPI.Domain.DTO;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDTO>
    {
        // Field to hold the unit of work instance
        private readonly IUnitOfWork _unitOfWork;

        // Constructor to initialize the unit of work instance
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Method to handle the create category command
        public async Task<CategoryDTO> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            // Create a new category entity with the name from the command
            var category = new Category { Name = command.Name };

            // Add the new category to the repository
            await _unitOfWork.Categories.AddAsync(category);

            // Save changes to the database
            await _unitOfWork.CompleteAsync();

            // Return a DTO of the created category
            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }
    }
}
