
using CrudNuevaVersionAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudNuevaVersionAPI.Context
{/// se crea la clase la cual creara todos los méotods que se conectaran a la base de datos
    // para que sea usada como un contexto de bd
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        // añadir entidades para que sean seteadas como unas tablas

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }

        // modelado de la informaxion  // definir como esraran estructuradas las tablas

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
