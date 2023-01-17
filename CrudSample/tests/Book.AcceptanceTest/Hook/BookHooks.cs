using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Book.AcceptanceTest.Hook
{
    [Binding]
    public  class BookHooks
    {
       private readonly IObjectContainer _objectContainer;

        public BookHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void RegisterServices()
        {
            var factory = GetWebApplicationFactory();
            _objectContainer.RegisterInstanceAs(factory);
        }

        private WebApplicationFactory<Program> GetWebApplicationFactory() =>
               new WebApplicationFactory<Program>()
                   .WithWebHostBuilder(builder =>
                   {
                       builder.ConfigureServices(services =>
                       {
                           var descriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<ProjectContext>));
                           services.Remove(descriptor);
                           services.AddDbContext<ProjectContext>(options =>
                           {
                               options.UseInMemoryDatabase("InMemoryDbForTesting");
                           });
                       });
                   });

    }
}