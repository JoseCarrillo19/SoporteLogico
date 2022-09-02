using Microsoft.EntityFrameworkCore;
using SoporteLogico.Models;

namespace SoporteLogico.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .HasMany<Vinculacion>(e => e.Vinculacions)
                .WithOne(v => v.Empleado)
                .HasForeignKey(v => v.IdEmpleado_Vinculacion);
        }


        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Vinculacion> Vinculacion { get; set; }

    }
}
