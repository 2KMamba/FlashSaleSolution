using FlashSale.DTOs;
using FlashSale.Models;
using FlashSale.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlashSale.Controllers
{
    public class EventoCompraController : Controller
    {
        private readonly StockService _service;
        private readonly ProductoService _productoService;
        private readonly KafkaProducerService _producer;

        public EventoCompraController(
            StockService service,
            ProductoService productoService,
            KafkaProducerService producer)
        {
            _service = service;
            _productoService = productoService;
            _producer = producer;
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

                // Enviar a Kafka
                await _producer.EnviarEvento(evento);
            }

            ViewBag.Productos = await _productoService.ObtenerTodos();
            ViewBag.Mensaje = $"{dto.CantidadEventos} eventos enviados a Kafka correctamente.";

            return View();
        }
    }
}
