using FlashSale.Models;
using FlashSale.Repositories;

namespace FlashSale.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _repository;

        public ProductoService(ProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _repository.ObtenerTodos();
        }

        public async Task Agregar(Producto producto)
        {
            await _repository.Agregar(producto);
        }
    }
}
