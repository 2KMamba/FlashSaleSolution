using FlashSale.DTOs;
using FlashSale.Models;
using FlashSale.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlashSale.Controllers
{
    public class EventoCompraController : Controller
    {
        private readonly StockService _service;

        public EventoCompraController(StockService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Generador()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Generador(GeneradorMasivoDTO dto)
        {
            for (int i = 0; i < dto.CantidadEventos; i++)
            {
                EventoCompra evento = new EventoCompra();

                evento.Id = Guid.NewGuid().ToString();

                evento.ProductoId = dto.ProductoId;

                evento.ClienteId = "CLI-" + Random.Shared.Next(1000, 9999);

                evento.Cantidad = dto.CantidadPorCompra;

                evento.Precio = 950;

                evento.Categoria = "Electrónica";

                evento.FechaHora = DateTime.Now;

                evento.Estado = "Pendiente";

                await _service.Agregar(evento);
            }

            ViewBag.Mensaje = "Eventos generados correctamente.";

            return View();
        }
    }
}
