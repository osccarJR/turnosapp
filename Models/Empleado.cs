using System.ComponentModel.DataAnnotations;

namespace TurnosApp.Models
{
    public class Empleado
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        // Relación con Departamento
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        
        public Departamento Departamento { get; set; }

        // Relación con Posicion
        [Display(Name = "Posición")]
        public int? PosicionId { get; set; }  // Nullable to allow for empty/initial value

        public Posicion Posicion { get; set; }  // Navigation property for Posicion
    }
}
