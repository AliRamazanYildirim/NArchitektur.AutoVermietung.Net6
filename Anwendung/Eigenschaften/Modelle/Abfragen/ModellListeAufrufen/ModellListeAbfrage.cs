using Anwendung.Dienste.Quellen;
using Anwendung.Eigenschaften.Marken.Abfragen.MarkeListeAufrufen;
using Anwendung.Eigenschaften.Marken.Modelle;
using Anwendung.Eigenschaften.Modelle.Modelle;
using AutoMapper;
using Core.Anwendung.Anfragen;
using Core.Persistenz.Paging;
using Domain.Einheiten;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Modelle.Abfragen.ModellListeAufrufen
{
    public class ModellListeAbfrage:IRequest<ModellListeModell>
    {
        public SeiteAnfrage SeiteAnfrage { get; set; }

        public class ModellListeAbfrageHandler : IRequestHandler<ModellListeAbfrage, ModellListeModell>
        {
            private readonly IModellQuelle _modellQuelle;
            private readonly IMapper _mapper;

            public ModellListeAbfrageHandler(IModellQuelle modellQuelle, IMapper mapper)
            {
                _modellQuelle = modellQuelle;
                _mapper = mapper;
            }

            public async Task<ModellListeModell> Handle(ModellListeAbfrage request, CancellationToken cancellationToken)
            {
                //Automodelle
               IPaginierung<Modell> modelle=await _modellQuelle.GeheZurListeAsync(include:m=>m.Include(c=>c.Marke),
                   index:request.SeiteAnfrage.Seite,size:request.SeiteAnfrage.Seitengrösse);
                //datenmodell
                ModellListeModell modell = _mapper.Map<ModellListeModell>(modelle);
                return modell;
            }
        }
    }
}
