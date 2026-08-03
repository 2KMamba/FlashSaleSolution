using FlashSale.DTOs;
using FlashSale.Models;
using FlashSale.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlashSale.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _service.ObtenerTodos();
            return View(productos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoDTO dto)
        {
            var producto = new Producto
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                Precio = dto.Precio,
                StockDisponible = dto.StockDisponible
            };

            await _service.Agregar(producto);

            return RedirectToAction("Index");
        }
    }
}
