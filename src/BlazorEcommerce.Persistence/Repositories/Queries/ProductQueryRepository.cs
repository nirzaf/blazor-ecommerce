using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Queries;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Queries
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductQueryRepository(PersistenceDataContext context)
        {
            _products = context.Products;
        }

        public async Task<IList<Product>> GetAllAdminProductAsync()
        {
            return await _products
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id, bool isAdminRole)
        {
            if (isAdminRole)
            {
                return await _products
                    .Find(p => p.Id == id)
                    .FirstOrDefaultAsync();
            }
            else
            {
                return await _products
                    .Find(p => p.Id == id && p.IsActive)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
