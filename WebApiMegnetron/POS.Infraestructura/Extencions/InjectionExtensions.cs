using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Infraestructura.Persistemces.Context;
using POS.Infraestructura.Persistemces.Interface;
using POS.Infraestructura.Persistemces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Infraestructura.Extencions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfraestructure(this IServiceCollection services,IConfiguration configuration) {
            var assembly = typeof(AplicationDbContext).Assembly.FullName;

            services.AddDbContext<AplicationDbContext>(
                options => options.UseSqlServer(
                        configuration.GetConnectionString("Conexion"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient
                    );
            services.AddTransient<IUnitOfWork, UnitOfWork>();

                return services;
                
        }
    }
}
