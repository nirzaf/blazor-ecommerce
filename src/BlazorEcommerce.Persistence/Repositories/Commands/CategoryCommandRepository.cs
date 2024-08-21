using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Commands;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Commands
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryCommandRepository(PersistenceDataContext context)
        {
            _categories = context.Categories;
        }

        public async Task AddAsync(Category entity)
        {
            await _categories.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Category> entities)
        {
            await _categories.InsertManyAsync(entities);
        }

        public async Task RemoveAsync(Category entity)
        {
            await _categories.DeleteOneAsync(c => c.Id == entity.Id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Category> entities)
        {
            var ids = entities.Select(e => e.Id);
            await _categories.DeleteManyAsync(c => ids.Contains(c.Id));
        }

        public async Task UpdateAsync(Category entity)
        {
            await _categories.ReplaceOneAsync(c => c.Id == entity.Id, entity);
        }
    }
}
