using Microsoft.EntityFrameworkCore;
using PruebaDemokrata.Core.Interface.Repository;
using PruebaDemokrata.Core.Interface;
using PruebaDemokrata.Core.Service;
using PruebaDemokrata.Infrastructure.Context;

namespace PruebaDemokrata.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<EFContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {            
            services.AddTransient<IUsuarioService, UsuarioService>();     
            
            return services;
        }


    }
}
