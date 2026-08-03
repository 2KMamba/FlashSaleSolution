using FlashSale.Models;
using FlashSale.Mongo;
using MongoDB.Driver;

namespace FlashSale.Repositories
{
    public class EventoRepository
    {
        private readonly MongoDbContext _context;

        public EventoRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<EventoCompra>> ObtenerTodos()
        {
            return await _context.Eventos
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task Agregar(EventoCompra evento)
        {
            await _context.Eventos.InsertOneAsync(evento);
        }
    }
}
