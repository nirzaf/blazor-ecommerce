using MongoDB.Driver;
using BlazorEcommerce.Application.Repositories.Queries;
using BlazorEcommerce.Domain.Entities;
using BlazorEcommerce.Persistence.Contexts;

namespace BlazorEcommerce.Persistence.Repositories.Queries
{
    public class ImageQueryRepository : IImageQueryRepository
    {
        private readonly IMongoCollection<Image> _images;

        public ImageQueryRepository(PersistenceDataContext context)
        {
            _images = context.Images;
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await _images.Find(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await _images.Find(_ => true).ToListAsync();
        }
    }
}
