using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Core.QuerSchnittsBedenken.Ausnahmen
{
    public class AusnahmeMiddleware
    {
        private readonly RequestDelegate _delegierteAnfrage;

        public AusnahmeMiddleware(RequestDelegate delegierteAnfrage)
        {
            _delegierteAnfrage = delegierteAnfrage;
        }
        public async Task Aufruf(HttpContext context)
        {
            try
            {
                await _delegierteAnfrage(context);
            }
            catch (Exception exception)
            {
                await AusnahmeBehandelnAsync(context, exception);
            }
        }

        private Task AusnahmeBehandelnAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            if (exception.GetType() == typeof(ValidationException)) return ValidierungAusnahmeErstellen(context, exception);
            if (exception.GetType() == typeof(AusnahmeFürTransaktion)) return FürTransaktionAusnahmeErstellen(context, exception);
            if (exception.GetType() == typeof(AutorisierungsAusnahme))
                return AutorisierungsAusnahmeErstellen(context, exception);
            return InterneAusnahmeErstellen(context, exception);
        }

        private Task AutorisierungsAusnahmeErstellen(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

            return context.Response.WriteAsync(new DetailsZumAutorisierungsProblem
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = "https://example.com/probs/authorization",
                Title = "Authorization exception",
                Detail = exception.Message,
                Instance = ""
            }.ToString());
        }

        private Task FürTransaktionAusnahmeErstellen(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

            return context.Response.WriteAsync(new TransaktionProblemDetail
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://example.com/probs/business",
                Title = "Business exception",
                Detail = exception.Message,
                Instance = ""
            }.ToString());
        }

        private Task ValidierungAusnahmeErstellen(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            object errors = ((ValidationException)exception).Errors;

            return context.Response.WriteAsync(new ValidierungsProblemDetail
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://example.com/probs/validation",
                Title = "Validierungsfehler",
                Detail = "",
                Instance = "",
                Errors = errors
            }.ToString());
        }

        private Task InterneAusnahmeErstellen(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

            return context.Response.WriteAsync(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/probs/internal",
                Title = "Internal exception",
                Detail = exception.Message,
                Instance = ""
            }.ToString());
        }
    }
}
