using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TurnosApp.Data;
using TurnosApp.Models;
using System.Linq;
using System.Threading.Tasks;

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
            if (!ValidarCedula(empleado.Cedula))
                ModelState.AddModelError("Cedula", "La cédula ingresada no es válida.");

            if (empleado.DepartamentoId == 0)
                ModelState.AddModelError("DepartamentoId", "Debe seleccionar un departamento.");

            if (empleado.PosicionId == null || empleado.PosicionId == 0)
                ModelState.AddModelError("PosicionId", "Debe seleccionar un cargo.");

            if (!ModelState.IsValid)
            {
                ViewBag.Departamentos = _context.Departamentos.ToList();
                return View(empleado);
            }

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

        // Método auxiliar para validar la cédula
        private bool ValidarCedula(string cedula)
        {
            // Aquí deberías implementar la lógica real de validación de cédula según tu país.
            // Esta es solo una validación básica de longitud.
            return !string.IsNullOrWhiteSpace(cedula) && cedula.Length == 11 && cedula.All(char.IsDigit);
        }
    }
}
