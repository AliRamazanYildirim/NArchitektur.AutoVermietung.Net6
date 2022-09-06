using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuerSchnittsBedenken.Ausnahmen
{
    public static class AusnahmeMiddlewareErweiterungen
    {
        public static void BenutzerdefinierteAusnahmeMiddlewareKonfigurieren(this IApplicationBuilder app)
        {
            app.UseMiddleware<AusnahmeMiddleware>();
        }
    }
}
