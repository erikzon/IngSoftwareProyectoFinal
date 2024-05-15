using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoftware.Models;

namespace proyectoIngSoftware.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<proyectoIngSoftware.Models.Estaciones> Estaciones { get; set; } = default!;
        public DbSet<proyectoIngSoftware.Models.Lineas> Lineas { get; set; } = default!;
        public DbSet<proyectoIngSoftware.Models.Empleados> Empleados { get; set; } = default!;
    }
}
