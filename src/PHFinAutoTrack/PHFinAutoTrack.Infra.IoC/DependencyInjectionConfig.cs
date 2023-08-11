using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PHFinAutoTrack.Application.Interfaces;
using PHFinAutoTrack.Application.Profiles;
using PHFinAutoTrack.Application.Services;
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

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            return services;
        }
    }
}
