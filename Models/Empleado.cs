using System.ComponentModel.DataAnnotations;

namespace TurnosApp.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = string.Empty;

        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }

        [Display(Name = "Posición")]
        public int? PosicionId { get; set; }
        public Posicion? Posicion { get; set; }
    }
}
