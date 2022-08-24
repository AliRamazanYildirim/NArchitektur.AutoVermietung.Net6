using Anwendung.Dienste.Quellen;
using Anwendung.Eigenschaften.Marken.Düoe;
using Anwendung.Eigenschaften.Marken.Regeln;
using AutoMapper;
using Domain.Einheiten;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Marken.Befehle.ErstellenMarke
{
    public class ErstellenMarkeEinheitsBefehl : IRequest<MarkeEinheitDüo>
    {
        public string Name { get; set; }
        public class ErstellenMarkeEinheitsBefehlHandler : IRequestHandler<ErstellenMarkeEinheitsBefehl, MarkeEinheitDüo>
        {
            private readonly IMarkeQuelle _markeQuelle;
            private readonly IMapper _mapper;
            private readonly MarkeEinheitGeschaeftsRegeln _markeEinheitGeschaeftsRegeln;

            public ErstellenMarkeEinheitsBefehlHandler(IMarkeQuelle markeQuelle, IMapper mapper, 
                MarkeEinheitGeschaeftsRegeln markeEinheitGeschaeftsRegeln)
            {
                _markeQuelle = markeQuelle;
                _mapper = mapper;
                _markeEinheitGeschaeftsRegeln = markeEinheitGeschaeftsRegeln;
            }

            
            public async Task<MarkeEinheitDüo> Handle(ErstellenMarkeEinheitsBefehl request, CancellationToken cancellationToken)
            {
                await _markeEinheitGeschaeftsRegeln.NameDerMarkenKannBeimEinfügenNichtDupliziertWerden(request.Name);

                Marke abgebildeteMarke = _mapper.Map<Marke>(request);
                Marke erstellteMarke = await _markeQuelle.InsertAsync(abgebildeteMarke);
                MarkeEinheitDüo erstellteMarkeEinheitDüo=_mapper.Map<MarkeEinheitDüo>(erstellteMarke);
                return erstellteMarkeEinheitDüo;

            }
        }
    }
}
