using MongoDB.Driver;

namespace BlazorEcommerce.Persistence.Repositories.Queries;

public class OrderQueryRepository : IOrderQueryRepository
{
    private readonly IMongoCollection<Order> _orders;

    public OrderQueryRepository(PersistenceDataContext context)
    {
        _orders = context.Orders;
    }

    public async Task<List<Order>> GetAllOrderByUserId(string userId)
    {
        return await _orders
                        .Find(o => o.UserId == userId)
                        .SortByDescending(o => o.OrderDate)
                        .ToListAsync();
    }

    public async Task<Order> GetOrderDetails(string userId, int id)
    {
        var order = await _orders
           .Find(o => o.UserId == userId && o.Id == id)
           .SortByDescending(o => o.OrderDate)
           .FirstOrDefaultAsync();

        return order;
    }
}
