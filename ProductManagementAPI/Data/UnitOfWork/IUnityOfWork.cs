using ProductManagementAPI.Domain.Repositories;

namespace ProductManagementAPI.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        // Property to access category-related data operations
        ICategoryRepository Categories { get; }

        // Property to access product-related data operations
        IProductRepository Products { get; }

        // Method to save changes to the database asynchronously
        Task<int> CompleteAsync();
    }
}
