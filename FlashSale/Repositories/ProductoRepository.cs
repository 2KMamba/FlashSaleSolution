using FlashSale.Models;
using FlashSale.Mongo;
using MongoDB.Driver;

namespace FlashSale.Repositories
{
    public class ProductoRepository
    {
        private readonly MongoDbContext _context;

        public ProductoRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _context.Productos
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task Agregar(Producto producto)
        {
            await _context.Productos.InsertOneAsync(producto);
        }
    }
}
