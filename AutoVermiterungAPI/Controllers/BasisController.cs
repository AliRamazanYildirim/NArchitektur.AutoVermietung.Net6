using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoVermiterungAPI.Controllers
{
    
    public class BasisController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
        protected string? GeheZurIpAdresse()
        {
            if (Request.Headers.ContainsKey("Für X-weitergeleitet"))
                return Request.Headers["Für X-weitergeleitet"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
