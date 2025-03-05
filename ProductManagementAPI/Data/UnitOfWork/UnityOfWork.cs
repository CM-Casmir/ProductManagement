using ProductManagementAPI.Domain.Repositories;

namespace ProductManagementAPI.Data.UnitOfWork
{
    // Defining the UnitOfWork class that implements the IUnitOfWork interface
    public class UnitOfWork : IUnitOfWork 
    {
        // Declaring a private readonly field for the database context
        private readonly ApplicationDbContext _context;

        // Constructor that takes an ApplicationDbContext as a parameter
        public UnitOfWork(ApplicationDbContext context) 
        {
            // Initializing the _context, Categories and Products 
            _context = context; 
            Categories = new CategoryRepository(_context);
            Products = new ProductRepository(_context); 
        }

        // Public property for accessing the Category repository and Product repository
        public ICategoryRepository Categories { get; private set; } 
        public IProductRepository Products { get; private set; }

        // Method to save changes to the database asynchronously
        public async Task<int> CompleteAsync() 
        {
            // Calling SaveChangesAsync on the context and returning the result
            return await _context.SaveChangesAsync(); 
        }
    }
}
