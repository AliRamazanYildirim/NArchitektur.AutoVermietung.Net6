using Core.Sicherheit.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit
{
    public static class RegistrierungDesSicherheitsDienstes
    {
        public static IServiceCollection SicherheitsDiensteHinzufügen(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelfer, JWTHelfer>();
          
            return services;
        }
    }
}
