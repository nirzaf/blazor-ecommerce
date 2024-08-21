using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Commands;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Commands
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderCommandRepository(PersistenceDataContext context)
        {
            _orders = context.Orders;
        }

        public async Task AddAsync(Order entity)
        {
            await _orders.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Order> entities)
        {
            await _orders.InsertManyAsync(entities);
        }

        public async Task RemoveAsync(Order entity)
        {
            await _orders.DeleteOneAsync(o => o.Id == entity.Id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Order> entities)
        {
            var ids = entities.Select(e => e.Id);
            await _orders.DeleteManyAsync(o => ids.Contains(o.Id));
        }

        public async Task UpdateAsync(Order entity)
        {
            await _orders.ReplaceOneAsync(o => o.Id == entity.Id, entity);
        }
    }
}
