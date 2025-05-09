using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurnosApp.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del Departamento")]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Empleado>? Empleados { get; set; }
        public ICollection<Posicion>? Posiciones { get; set; }
    }
}
