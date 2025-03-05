using MediatR;
using ProductManagementAPI.Application.Categories.Queries.GetAllCategoryById;
using ProductManagementAPI.Data.UnitOfWork;
using ProductManagementAPI.Domain.DTO;

namespace ProductManagementAPI.Application.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDTO> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(query.Id);
            if (category == null) return null;

            return new CategoryDTO { Id = category.Id, Name = category.Name };
        }
    }
}
