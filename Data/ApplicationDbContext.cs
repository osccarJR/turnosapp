using Microsoft.EntityFrameworkCore;
using TurnosApp.Models;

namespace TurnosApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        // Add the DbSet for Posicion
        public DbSet<Posicion> Posiciones { get; set; }
    }
}
