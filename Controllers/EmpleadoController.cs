using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnosApp.Data;
using TurnosApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace TurnosApp.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpleadoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var empleados = await _context.Empleados
                .Include(e => e.Departamento)
                .Include(e => e.Posicion)
                .ToListAsync();

            return View(empleados);
        }

        public IActionResult Create()
        {
            ViewBag.Departamentos = _context.Departamentos.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            // 🔴 Prueba temporal: sin validación
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetPosiciones(int departamentoId)
        {
            var posiciones = _context.Posiciones
                .Where(p => p.DepartamentoId == departamentoId)
                .Select(p => new { p.Id, p.Nombre })
                .ToList();

            return Json(posiciones);
        }
    }
}
