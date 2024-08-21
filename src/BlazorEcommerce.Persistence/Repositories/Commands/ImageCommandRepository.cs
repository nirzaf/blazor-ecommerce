using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Commands;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Commands
{
    public class ImageCommandRepository : IImageCommandRepository
    {
        private readonly IMongoCollection<Image> _images;

        public ImageCommandRepository(PersistenceDataContext context)
        {
            _images = context.Images;
        }

        public async Task AddAsync(Image entity)
        {
            await _images.InsertOneAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Image> entities)
        {
            await _images.InsertManyAsync(entities);
        }

        public async Task RemoveAsync(Image entity)
        {
            await _images.DeleteOneAsync(i => i.Id == entity.Id);
        }

        public async Task RemoveRangeAsync(IEnumerable<Image> entities)
        {
            var ids = entities.Select(e => e.Id);
            await _images.DeleteManyAsync(i => ids.Contains(i.Id));
        }

        public async Task UpdateAsync(Image entity)
        {
            await _images.ReplaceOneAsync(i => i.Id == entity.Id, entity);
        }
    }
}
