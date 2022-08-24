using Anwendung.Eigenschaften.Marken.Befehle.ErstellenMarke;
using Anwendung.Eigenschaften.Marken.Düoe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoVermiterungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkenController : BasisController
    {
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ErstellenMarkeEinheitsBefehl erstellenMarkeEinheitsBefehl)
        {
            MarkeEinheitDüo resultat = await Mediator.Send(erstellenMarkeEinheitsBefehl);
            return Created("", resultat);
        }
    }
}
