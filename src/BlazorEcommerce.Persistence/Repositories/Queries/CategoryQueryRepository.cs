using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Queries;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Queries
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryQueryRepository(PersistenceDataContext context)
        {
            _categories = context.Categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categories.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categories.Find(_ => true).ToListAsync();
        }
    }
}
