using Anwendung.Dienste.Quellen;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistenz.Kontexte;
using Persistenz.Quellen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistenz
{
    public static class PersistenzDienstRegistrierung
    {
        public static IServiceCollection DienstePersistenzHinzufügen(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<BasisDbKontext>(options =>
                 options.UseSqlServer(
                 configuration.GetConnectionString("AutoVermiterungConnectionString")));
            services.AddScoped<IMarkeQuelle, MarkeQuelle>();
            services.AddScoped<IModellQuelle, ModellQuelle>();

            return services;
        }
    }
}
