using FlashSale.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlashSale.Controllers
{
    public class DashboardController : Controller
    {
        private readonly EventoRepository _repository;

        public DashboardController(EventoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var eventos = await _repository.ObtenerTodos();

            return View(eventos);
        }
    }
}
