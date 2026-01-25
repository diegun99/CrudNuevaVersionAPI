
using CrudNuevaVersionAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)// modelado de la informacion para la base de datos
        {

            modelBuilder.Entity<Perfil>(tb =>
            {
                tb.HasKey(col => col.IdPerfil); //  haskey define la llave primaria,, cuando en el dto se coloca Id , no es necesario definir esta propiedad, pero para efectos practicos y teniendo un mayor control, se define como IdPerfil y aqui se le ajustan las propiedades
                tb.Property(col => col.IdPerfil).UseIdentityColumn().ValueGeneratedOnAdd();/// genera un autoincrementable siempre que se agregue un valor
                tb.Property(col => col.Nombre).HasMaxLength(50); //establece el valor maximo del nvarchar 
                tb.ToTable("Perfil");/// establece el nombre de la Tabla

                                     /// si quieres añadir informacion a la tabla de inmediato seed data (los objetos)
                tb.HasData(
                    new Perfil { IdPerfil = 1, Nombre = "Programador Dev" },// aqui es necesario establecer el idperfil,a pesar de lo incrementable
                    new Perfil { IdPerfil = 2, Nombre = "Programador Senior" },
                    new Perfil { IdPerfil = 3, Nombre = "Analista" }
                    );

            });

            modelBuilder.Entity<Empleado>(tb =>
            {
                tb.HasKey(col => col.IdEmpleado); //  haskey define la llave primaria,, cuando en el dto se coloca Id , no es necesario definir esta propiedad, pero para efectos practicos y teniendo un mayor control, se define como IdPerfil y aqui se le ajustan las propiedades
                tb.Property(col => col.IdEmpleado).UseIdentityColumn().ValueGeneratedOnAdd();/// genera un autoincrementable siempre que se agregue un valor
                tb.Property(col => col.NombreCompleto).HasMaxLength(100); //establece el valor maximo del nvarchar 

                /// establece la relacion entre Empleado y la tabla Perfil
                tb.HasOne(col => col.PerfilReferencia).WithMany(p => p.EmpleadosReferencia)// la tabla empleado se relaciona con perfilPreferencia pero este perfil puede tener muchos empleados
                .HasForeignKey(p => p.IdPerfil);
                tb.ToTable("Empleado");/// establece el nombre de la Tabla, por lo general se deja al final


            }


            );


            //base.OnModelCreating(modelBuilder);
        }
    }
}
