using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

// using this with IConfiguration
using Microsoft.Extensions.Configuration;

// using this with IServiceCollection
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CleanArchDatabase"), builder =>
                 {
                     builder.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName);
                 });
            }, ServiceLifetime.Transient);

            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDBContext>());



            return services;

        }



    }
}