using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
    // método de extensão do tipo IServiceCollection.
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //registrando o contexto:
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
        );

        // registrando os serviços:
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
