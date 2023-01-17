using Books.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Books.Persistence
{
    public static class PrepDb
    {
        public static void PrepPopulation(IServiceProvider service)
        {
            using (var serviceScope = service.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProjectContext>();
                
                context.Database.Migrate();
                SeedData(context);
            }
        }
        private static void SeedData(ProjectContext context)
        {
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Author("Bahare"),
                    new Author("Shiva"));

                context.SaveChanges();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new BookEntity("Book1",32.25m," ",1),
                    new BookEntity("Book2", 20.25m, " ", 2));

                context.SaveChanges();
            }
        }
    }
}
