using Microsoft.EntityFrameworkCore;

namespace MvcApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Courses { get; set; } = null!;

        public DbSet<Teacher> Teachers { get; set; } = null!;

        public DbSet<Student> Students { get; set; } = null!;

        public DbSet<Organisation> Organisations { get; set; } = null!;

        public DbSet<UchGroupe> UchGroupes { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }
    }
}