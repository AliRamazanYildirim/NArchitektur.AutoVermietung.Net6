using Anwendung.Dienste.Quellen;
using Anwendung.Eigenschaften.Marken.Modelle;
using AutoMapper;
using Core.Anwendung.Anfragen;
using Core.Persistenz.Paging;
using Domain.Einheiten;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Marken.Abfragen.MarkeListeAufrufen
{

    public class AbfrageDerListeMarke:IRequest<MarkeListeModell>
    {
        public SeiteAnfrage SeiteAnfrage { get; set; }

        public class AbfrageDerListeMarkeAbrufenHandler : IRequestHandler<AbfrageDerListeMarke, MarkeListeModell>
        {
            private readonly IMarkeQuelle _markeQuelle;
            private readonly IMapper _mapper;

            public AbfrageDerListeMarkeAbrufenHandler(IMarkeQuelle markeQuelle, IMapper mapper)
            {
                _markeQuelle = markeQuelle;
                _mapper = mapper;
            }

            public async Task<MarkeListeModell> Handle(AbfrageDerListeMarke request, CancellationToken cancellationToken)
            {
                IPaginierung<Marke> marken=await _markeQuelle.GeheZurListeAsync(index: request.SeiteAnfrage.Seite,
                    size: request.SeiteAnfrage.Seitengrösse);
                MarkeListeModell abgebildeteMarkeListeModell = _mapper.Map<MarkeListeModell>(marken);
                return abgebildeteMarkeListeModell;
            }
        }
    }
}
