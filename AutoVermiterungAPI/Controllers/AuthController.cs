using Anwendung.Eigenschaften.Authen.Befehle.Anmelden;
using Anwendung.Eigenschaften.Authen.Düoe;
using Core.Sicherheit.Düoe;
using Core.Sicherheit.Einheiten;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AutoVermiterungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BasisController
    {
        [HttpPost("Registrieren")]
        public async Task<IActionResult> Registrieren([FromBody] BenutzerFürRegistrierungDüo benutzerFürRegistrierungDüo)
        {
            BefehlRegistrieren befehlRegistrieren = new()
            {
                BenutzerFürRegistrierungDüo=benutzerFürRegistrierungDüo,
                IpAdresse=GeheZurIpAdresse()
            };
            EingetragenDüo resultat = await Mediator.Send(befehlRegistrieren);
            StellenAktualisierungsTokenAufCookieEin(resultat.TokenAktualisieren);
            return Created("", resultat.ZugangsToken);

        }
        private void StellenAktualisierungsTokenAufCookieEin(TokenAktualisieren tokenAktualisieren)
        {
            CookieOptions cookieOptions = new()
            {
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(7)
            };
            Response.Cookies.Append("tokenAktualisieren", tokenAktualisieren.Token, cookieOptions);
        }
    }
}
