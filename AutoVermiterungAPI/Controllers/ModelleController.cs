using Anwendung.Eigenschaften.Modelle.Abfragen.ModellListeAufrufen;
using Anwendung.Eigenschaften.Modelle.Abfragen.NachDynamikModellListeAufrufen;
using Anwendung.Eigenschaften.Modelle.Modelle;
using Core.Anwendung.Anfragen;
using Core.Persistenz.Dynamik;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoVermiterungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelleController : BasisController
    {
        [HttpGet]
        public async Task<IActionResult> ListeAufrufen([FromQuery] SeiteAnfrage seiteAnfrage)
        {
            ModellListeAbfrage modellListeAbfrage = new ModellListeAbfrage { SeiteAnfrage=seiteAnfrage};
            ModellListeModell resultat = await Mediator.Send(modellListeAbfrage);
            return Ok(resultat);
        }
        [HttpPost("ListeAufrufen/NachDynamik")]
        public async Task<IActionResult> ListeNachDynamikAufrufen([FromQuery] SeiteAnfrage seiteAnfrage,
            [FromBody] Dynamik dynamik)
        {
            AbfrageDerModellListeNachDynamik abfrageDerModellListeNachDynamik = new AbfrageDerModellListeNachDynamik 
            { SeiteAnfrage = seiteAnfrage, Dynamik=dynamik };
            ModellListeModell resultat = await Mediator.Send(abfrageDerModellListeNachDynamik);
            return Ok(resultat);
        }
    }
}
