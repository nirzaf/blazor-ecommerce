using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Commands;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Commands
{
    public class AddressCommandRepository : IAddressCommandRepository
    {
        private readonly IMongoCollection<Address> _addresses;

        public AddressCommandRepository(PersistenceDataContext context)
        {
            _addresses = context.Addresses;
        }

        public async Task AddAsync(Address entity)
        {
            await _addresses.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Address> entities)
        {
            await _addresses.InsertManyAsync(entities);
        }

        public async Task RemoveAsync(Address entity)
        {
            await _addresses.DeleteOneAsync(a => a.Id == entity.Id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Address> entities)
        {
            var ids = entities.Select(e => e.Id);
            await _addresses.DeleteManyAsync(a => ids.Contains(a.Id));
        }

        public async Task UpdateAsync(Address entity)
        {
            await _addresses.ReplaceOneAsync(a => a.Id == entity.Id, entity);
        }
    }
}
