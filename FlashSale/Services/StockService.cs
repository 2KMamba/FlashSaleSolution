using FlashSale.Models;
using FlashSale.Repositories;

namespace FlashSale.Services
{
    public class StockService
    {
        private readonly EventoRepository _repository;

        public StockService(EventoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EventoCompra>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();
        }

        public async Task Agregar(EventoCompra evento)
        {
            await _repository.Agregar(evento);
        }
    }
}
