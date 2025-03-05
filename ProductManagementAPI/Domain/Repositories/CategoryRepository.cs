using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Domain.Entities;


namespace ProductManagementAPI.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            // Injecting ApplicationDbContext for database operations
            _context = context; 
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            // Fetch all categories from database asynchronously
            return await _context.Categories.ToListAsync(); 
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            // Fetch category by ID asynchronously

            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddAsync(Category category)
        {
            // Add new category to database asynchronously
            await _context.Categories.AddAsync(category); 
        }

        public void Update(Category category)
        {
            // Update existing category in database context
            _context.Categories.Update(category); 
        }

        public void Delete(Category category)
        {
            // Remove specified category from database context
            _context.Categories.Remove(category); 
        }
    }
}
