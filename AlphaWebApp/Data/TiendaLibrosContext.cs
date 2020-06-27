using Microsoft.EntityFrameworkCore;

namespace AlphaWebApp.Data
{
    public class TiendaLibrosContext : DbContext
    {
        //constructor que recibe la conexion desde el startup.cs
        public TiendaLibrosContext(DbContextOptions<TiendaLibrosContext> options) : base(options)
        {

        }

        public DbSet<Libros> Libros {get; set;}

        public DbSet<Idiomas> Idiomas {get; set;}

        //Define la cadena de conexion a la BD desde esta clase, pero tambien se puede hacer en el StartUp.cs
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySql("Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}