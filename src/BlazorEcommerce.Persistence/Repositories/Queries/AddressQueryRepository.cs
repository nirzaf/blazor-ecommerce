using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Queries;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Queries
{
    public class AddressQueryRepository : IAddressQueryRepository
    {
        private readonly IMongoCollection<Address> _addresses;

        public AddressQueryRepository(PersistenceDataContext context)
        {
            _addresses = context.Addresses;
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _addresses.Find(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _addresses.Find(_ => true).ToListAsync();
        }
    }
}
