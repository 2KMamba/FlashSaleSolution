using FlashSale.DTOs;
using FlashSale.Models;
using FlashSale.Services;
using Microsoft.AspNetCore.Mvc;
using FlashSale.Repositories;

namespace FlashSale.Controllers
{
    public class EventoCompraController : Controller
    {
        private readonly StockService _service;
        private readonly ProductoService _productoService;

        public EventoCompraController(
            StockService service,
            ProductoService productoService)
        {
            _service = service;
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<IActionResult> Generador()
        {
            ViewBag.Productos = await _productoService.ObtenerTodos();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Generador(GeneradorMasivoDTO dto)
        {
            for (int i = 0; i < dto.CantidadEventos; i++)
            {
                EventoCompra evento = new EventoCompra
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductoId = dto.ProductoId,
                    ClienteId = "CLI-" + Random.Shared.Next(1000, 9999),
                    Cantidad = dto.CantidadPorCompra,
                    Precio = 950,
                    Categoria = "Electrónica",
                    FechaHora = DateTime.Now,
                    Estado = dto.Modo
                };

                await _service.Agregar(evento);
            }

            ViewBag.Productos = await _productoService.ObtenerTodos();
            ViewBag.Mensaje = $"{dto.CantidadEventos} eventos generados correctamente.";

            return View();
        }
    }
}
