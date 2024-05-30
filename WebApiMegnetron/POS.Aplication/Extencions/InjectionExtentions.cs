using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using POS.Aplication.Interfaces;
using POS.Aplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Extencions
{
    public static class InjectionExtentions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);

            services.AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
                });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IProductoAplication, ProductoAplication>();
            services.AddScoped<IPersonaApplication, PersonaApplication>();
            services.AddScoped<IFacturaApplication, FacturaApplication>();

            return services;

        }

    }
}
