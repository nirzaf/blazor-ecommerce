using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Commands;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Commands
{
    public class OrderItemCommandRepository : IOrderItemCommandRepository
    {
        private readonly IMongoCollection<OrderItem> _orderItems;

        public OrderItemCommandRepository(PersistenceDataContext context)
        {
            _orderItems = context.OrderItems;
        }

        public async Task AddAsync(OrderItem entity)
        {
            await _orderItems.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<OrderItem> entities)
        {
            await _orderItems.InsertManyAsync(entities);
        }

        public async Task RemoveAsync(OrderItem entity)
        {
            await _orderItems.DeleteOneAsync(oi => oi.Id == entity.Id);
        }

        public async Task RemoveRangeAsync(IEnumerable<OrderItem> entities)
        {
            var ids = entities.Select(e => e.Id);
            await _orderItems.DeleteManyAsync(oi => ids.Contains(oi.Id));
        }

        public async Task UpdateAsync(OrderItem entity)
        {
            await _orderItems.ReplaceOneAsync(oi => oi.Id == entity.Id, entity);
        }
    }
}
