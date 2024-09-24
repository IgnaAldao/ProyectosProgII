using Microsoft.EntityFrameworkCore;

namespace Clase_24_09.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Rol> Roles{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>().Navigation(e => e.Rol).AutoInclude();
        }
    }
}
