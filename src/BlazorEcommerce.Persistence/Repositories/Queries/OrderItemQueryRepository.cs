using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Queries;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Queries
{
    public class OrderItemQueryRepository : IOrderItemQueryRepository
    {
        private readonly IMongoCollection<OrderItem> _orderItems;

        public OrderItemQueryRepository(PersistenceDataContext context)
        {
            _orderItems = context.OrderItems;
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await _orderItems.Find(oi => oi.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _orderItems.Find(_ => true).ToListAsync();
        }
    }
}
