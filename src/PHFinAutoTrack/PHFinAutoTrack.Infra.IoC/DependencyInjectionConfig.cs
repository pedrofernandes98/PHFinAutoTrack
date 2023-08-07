using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PHFinAutoTrack.Domain.Interfaces;
using PHFinAutoTrack.Infra.Data.Context;
using PHFinAutoTrack.Infra.Data.Repositories;

namespace PHFinAutoTrack.Infra.IoC
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            return services;
        }
    }
}
