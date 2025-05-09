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
            var empleados = await _context.Empleados.Include(e => e.Departamento).ToListAsync();
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
            {
                ModelState.AddModelError("Cedula", "La cédula ingresada no es válida.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Departamentos = _context.Departamentos.ToList();
                return View(empleado);
            }

            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Method to validate the Cedula
        private bool ValidarCedula(string cedula)
        {
            if (cedula.Length != 10) return false;
            int suma = 0;
            for (int i = 0; i < 9; i++)
            {
                int num = int.Parse(cedula[i].ToString());
                int coef = (i % 2 == 0) ? 2 : 1;
                int res = num * coef;
                if (res > 9) res -= 9;
                suma += res;
            }
            int digitoVerificador = (10 - (suma % 10)) % 10;
            return digitoVerificador == int.Parse(cedula[9].ToString());
        }

        // New GET method to fetch the Posiciones based on the selected Departamento
        [HttpGet]
        public IActionResult GetPosiciones(int departamentoId)
        {
            var posiciones = _context.Posiciones
                .Where(p => p.DepartamentoId == departamentoId)  // Assuming there's a DepartamentoId in Posicion
                .Select(p => new { p.Id, p.Nombre })
                .ToList();

            return Json(posiciones);
        }
    }
}
