using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Commands;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Commands
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductCommandRepository(PersistenceDataContext context)
        {
            _products = context.Products;
        }

        public async Task AddAsync(Product entity)
        {
            await _products.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Product> entities)
        {
            await _products.InsertManyAsync(entities);
        }

        public async Task RemoveAsync(Product entity)
        {
            await _products.DeleteOneAsync(p => p.Id == entity.Id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            var ids = entities.Select(e => e.Id);
            await _products.DeleteManyAsync(p => ids.Contains(p.Id));
        }

        public async Task UpdateAsync(Product entity)
        {
            await _products.ReplaceOneAsync(p => p.Id == entity.Id, entity);
        }
    }
}
