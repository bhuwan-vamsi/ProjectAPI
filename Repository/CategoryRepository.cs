using APIPractice.Data;
using APIPractice.Models.Domain;
using APIPractice.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace APIPractice.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await db.Categories.ToListAsync();
            return categories;
        }
    }
}
