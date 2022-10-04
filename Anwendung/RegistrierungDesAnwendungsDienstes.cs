using Anwendung.Dienste.AuthDienst;
using Anwendung.Eigenschaften.Authen.Regeln;
using Anwendung.Eigenschaften.Marken.Regeln;
using Core.Anwendung.Rohrleitungen.Validierung;
using FluentValidation;
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
            services.AddScoped<AuthGeschaeftsRegeln>();


            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AnforderungsValidierungsVerhalten<,>));

            services.AddScoped<IAuthDienst, AuthManager>();

            return services;

        }
    }
}
