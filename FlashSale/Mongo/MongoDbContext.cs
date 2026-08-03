using FlashSale.Configurations;
using FlashSale.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlashSale.Mongo
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);

            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Producto> Productos =>
            _database.GetCollection<Producto>("Productos");

        public IMongoCollection<EventoCompra> Eventos =>
            _database.GetCollection<EventoCompra>("Eventos");

        public IMongoCollection<BalanceStock> BalanceStock =>
            _database.GetCollection<BalanceStock>("BalanceStock");

        public IMongoCollection<Cliente> Clientes =>
            _database.GetCollection<Cliente>("Clientes");
    }
}
