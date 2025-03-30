using Microsoft.AspNetCore.Mvc;
using SalonTurnos.Services;

namespace SalonTurnos.Controllers
{
    public class TurnosController : Controller
    {
        private readonly TurnoService _turnoService;

        public TurnosController(TurnoService turnoService)
        {
            _turnoService =turnoService;
        }

        public async Task<IActionResult> Index(bool? disponible, int? salonId)
        {
            var turnos = await _turnoService.GetTurnosAsync(disponible, salonId);

            return View(turnos);
        }
    }
}
