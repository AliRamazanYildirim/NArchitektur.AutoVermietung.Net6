using Anwendung.Eigenschaften.Marken.Befehle.ErstellenMarke;
using Anwendung.Eigenschaften.Marken.Düoe;
using Anwendung.Eigenschaften.Marken.Modelle;
using AutoMapper;
using Core.Persistenz.Paging;
using Domain.Einheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Marken.Profil
{
    public class KartierungProfil : Profile
    {
        public KartierungProfil()
        {
            CreateMap<Marke, MarkeEinheitDüo>().ReverseMap();
            CreateMap<Marke, ErstellenMarkeEinheitsBefehl>().ReverseMap();
            CreateMap<IPaginierung<Marke>, MarkeListeModell>().ReverseMap();
            CreateMap<Marke, MarkeListeDüo>().ReverseMap();
            CreateMap<Marke, NachMarkeIdAbrufenDüo>().ReverseMap();
        }
    }
}
