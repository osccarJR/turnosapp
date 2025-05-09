using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TurnosApp.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del Departamento")]
        public string Nombre { get; set; }

        public ICollection<Empleado> Empleados { get; set; }

        // Add the collection for Posiciones
        public ICollection<Posicion> Posiciones { get; set; }
    }
}
