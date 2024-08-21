using MongoDB.Driver;

namespace BlazorEcommerce.Persistence.Contexts;

public class PersistenceDbContextInitialiser
{
    private readonly PersistenceDataContext _context;

    public PersistenceDbContextInitialiser(PersistenceDataContext context)
    {
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        await InitialiseWithMongoDbAsync();
    }

    private async Task InitialiseWithMongoDbAsync()
    {
        _context.Configure();
        await Task.CompletedTask;
    }
}
