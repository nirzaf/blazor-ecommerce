using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace BlazorEcommerce.Persistence.Contexts
{
    public class PersistenceDataContext
    {
        private readonly IMongoDatabase _database;

        public PersistenceDataContext(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("BlazorEcommerceDb");
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>("Products");

        public IMongoCollection<Category> Categories => _database.GetCollection<Category>("Categories");

        public IMongoCollection<ProductType> ProductTypes => _database.GetCollection<ProductType>("ProductTypes");

        public IMongoCollection<ProductVariant> ProductVariants => _database.GetCollection<ProductVariant>("ProductVariants");

        public IMongoCollection<CartItem> CartItems => _database.GetCollection<CartItem>("CartItems");

        public IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");

        public IMongoCollection<OrderItem> OrderItems => _database.GetCollection<OrderItem>("OrderItems");

        public IMongoCollection<Address> Addresses => _database.GetCollection<Address>("Addresses");

        public IMongoCollection<Image> Images => _database.GetCollection<Image>("Images");

        public void Configure()
        {
            BsonClassMap.RegisterClassMap<CartItem>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.UserId));
                cm.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<ProductVariant>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(p => p.ProductId));
                cm.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<OrderItem>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(oi => oi.OrderId));
                cm.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<Address>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(a => a.Id));
                cm.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
                cm.SetIgnoreExtraElements(true);
            });
        }
    }
}
