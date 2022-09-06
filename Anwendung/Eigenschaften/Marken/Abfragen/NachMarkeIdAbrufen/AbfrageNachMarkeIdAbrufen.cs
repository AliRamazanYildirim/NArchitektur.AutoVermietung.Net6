using Anwendung.Dienste.Quellen;
using Anwendung.Eigenschaften.Marken.Abfragen.MarkeListeAbrufen;
using Anwendung.Eigenschaften.Marken.Düoe;
using Anwendung.Eigenschaften.Marken.Modelle;
using Anwendung.Eigenschaften.Marken.Regeln;
using AutoMapper;
using Core.Persistenz.Paging;
using Domain.Einheiten;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Marken.Abfragen.NachMarkeIdAbrufen
{
    public class AbfrageNachMarkeIdAbrufen:IRequest<NachMarkeIdAbrufenDüo>
    {
        public int Id { get; set; }
        public class AbfrageNachMarkeIdAbrufenHandler : IRequestHandler<AbfrageNachMarkeIdAbrufen, NachMarkeIdAbrufenDüo>
        {
            private readonly IMarkeQuelle _markeQuelle;
            private readonly IMapper _mapper;
            private readonly MarkeEinheitGeschaeftsRegeln _markeEinheitGeschaeftsRegeln;

            public AbfrageNachMarkeIdAbrufenHandler(IMarkeQuelle markeQuelle, IMapper mapper, MarkeEinheitGeschaeftsRegeln markeEinheitGeschaeftsRegeln)
            {
                _markeQuelle = markeQuelle;
                _mapper = mapper;
                _markeEinheitGeschaeftsRegeln = markeEinheitGeschaeftsRegeln;
            }

            public async Task<NachMarkeIdAbrufenDüo> Handle(AbfrageNachMarkeIdAbrufen request, CancellationToken cancellationToken)
            {
                Marke? marke= await _markeQuelle.GeheZurAsync(m => m.Id == request.Id);
                _markeEinheitGeschaeftsRegeln.MarkeSollteAufAnfrageVorhandenSein(marke);
                NachMarkeIdAbrufenDüo nachMarkeIdAbrufenDüo=_mapper.Map<NachMarkeIdAbrufenDüo>(marke);
                return nachMarkeIdAbrufenDüo;
            }
        }
    }
}
