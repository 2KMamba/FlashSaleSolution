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

        public IActionResult Generador()
        {
            return View();
        }
    }
}
