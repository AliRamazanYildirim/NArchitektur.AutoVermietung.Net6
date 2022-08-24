using Anwendung.Eigenschaften.Marken.Regeln;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung
{
    public static class RegistrierungDesAnwendungsDienstes
    {
        public static IServiceCollection AnwendungsDiensteHinzufügen(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<MarkeEinheitGeschaeftsRegeln>();

            

            return services;

        }
    }
}
