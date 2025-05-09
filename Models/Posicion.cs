using System.ComponentModel.DataAnnotations;

namespace TurnosApp.Models
{
    public class Posicion
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del Cargo o Posición")]
        public string Nombre { get; set; }

        // Relación con Departamento
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
