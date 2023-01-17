using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
