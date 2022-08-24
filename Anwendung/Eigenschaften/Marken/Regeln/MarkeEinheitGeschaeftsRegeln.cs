using Anwendung.Dienste.Quellen;
using Core.Persistenz.Paging;
using Core.QuerSchnittsBedenken.Ausnahmen;
using Domain.Einheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Anwendung.Eigenschaften.Marken.Regeln
{
    public class MarkeEinheitGeschaeftsRegeln
    {
        private readonly IMarkeQuelle _markeQuelle;

        public MarkeEinheitGeschaeftsRegeln(IMarkeQuelle markeQuelle)
        {
            _markeQuelle = markeQuelle;
        }
        public async Task NameDerMarkenKannBeimEinfügenNichtDupliziertWerden(string name)
        {
            IPaginierung<Marke> result = await _markeQuelle.GeheZurListeAsync(b => b.Name == name);
            if (result.Element.Any()) throw new GeschaeflicheAusnahmen("SomeFeatureEntity name exists.");
        }
    }
}
