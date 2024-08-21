using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Queries;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Queries
{
    public class CartItemQueryRepository : ICartItemQueryRepository
    {
        private readonly IMongoCollection<CartItem> _cartItems;

        public CartItemQueryRepository(PersistenceDataContext context)
        {
            _cartItems = context.CartItems;
        }

        public async Task<CartItem> GetByIdAsync(int id)
        {
            return await _cartItems.Find(ci => ci.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _cartItems.Find(_ => true).ToListAsync();
        }
    }
}
