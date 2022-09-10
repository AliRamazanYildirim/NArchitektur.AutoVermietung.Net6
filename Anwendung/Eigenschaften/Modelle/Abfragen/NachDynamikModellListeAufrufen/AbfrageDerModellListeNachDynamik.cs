using Anwendung.Dienste.Quellen;
using Anwendung.Eigenschaften.Modelle.Abfragen.ModellListeAufrufen;
using Anwendung.Eigenschaften.Modelle.Modelle;
using AutoMapper;
using Core.Anwendung.Anfragen;
using Core.Persistenz.Dynamik;
using Core.Persistenz.Paging;
using Domain.Einheiten;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Modelle.Abfragen.NachDynamikModellListeAufrufen
{
    public class AbfrageDerModellListeNachDynamik : IRequest<ModellListeModell>
    {
        public Dynamik Dynamik { get; set; }
        public SeiteAnfrage SeiteAnfrage { get; set; }

        public class AbfrageDerModellListeNachDynamikHandler : IRequestHandler<AbfrageDerModellListeNachDynamik, ModellListeModell>
        {
            private readonly IModellQuelle _modellQuelle;
            private readonly IMapper _mapper;

            public AbfrageDerModellListeNachDynamikHandler(IModellQuelle modellQuelle, IMapper mapper)
            {
                _modellQuelle = modellQuelle;
                _mapper = mapper;
            }

            public async Task<ModellListeModell> Handle(AbfrageDerModellListeNachDynamik request, CancellationToken cancellationToken)
            {
                //Automodelle
                    IPaginierung<Modell> modelle = await _modellQuelle.GeheZurListeNachDynamischAsync(request.Dynamik,
                        include:m => m.Include(c => c.Marke),index: request.SeiteAnfrage.Seite, size: request.SeiteAnfrage.Seitengrösse);
                //datenmodell
                ModellListeModell modell = _mapper.Map<ModellListeModell>(modelle);
                return modell;
            }

            
        }
    }
}
