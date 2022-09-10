using Anwendung.Eigenschaften.Marken.Abfragen.MarkeListeAufrufen;
using Anwendung.Eigenschaften.Marken.Abfragen.NachMarkeIdAufrufen;
using Anwendung.Eigenschaften.Marken.Befehle.ErstellenMarke;
using Anwendung.Eigenschaften.Marken.Düoe;
using Anwendung.Eigenschaften.Marken.Modelle;
using Core.Anwendung.Anfragen;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoVermiterungAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkenController : BasisController
    {
        [HttpGet]
        public async Task<IActionResult> GeheZurListe([FromQuery] SeiteAnfrage seiteAnfrage)
        {
            AbfrageDerListeMarke abfrageDerListeMarkeAbrufen = new() { SeiteAnfrage = seiteAnfrage };
            MarkeListeModell resultat = await Mediator.Send(abfrageDerListeMarkeAbrufen);
            return Ok(resultat);


        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ErstellenMarkeEinheitsBefehl erstellenMarkeEinheitsBefehl)
        {
            MarkeEinheitDüo resultat = await Mediator.Send(erstellenMarkeEinheitsBefehl);
            return Created("", resultat);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> NachIdAbrufen([FromRoute] AbfrageNachMarkeId abfrageNachMarkeId)
        {
            NachMarkeIdAbrufenDüo nachMarkeIdAbrufenDüo= await Mediator.Send(abfrageNachMarkeId);
            return Ok(nachMarkeIdAbrufenDüo);
            
        }
    }
}
