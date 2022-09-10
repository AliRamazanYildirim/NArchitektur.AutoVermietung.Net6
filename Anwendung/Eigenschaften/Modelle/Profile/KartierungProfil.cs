using Anwendung.Eigenschaften.Marken.Befehle.ErstellenMarke;
using Anwendung.Eigenschaften.Marken.Düoe;
using Anwendung.Eigenschaften.Marken.Modelle;
using Anwendung.Eigenschaften.Modelle.Düo;
using Anwendung.Eigenschaften.Modelle.Modelle;
using AutoMapper;
using Core.Persistenz.Paging;
using Domain.Einheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Modelle.Profil
{
    public class KartierungProfil : Profile
    {
        public KartierungProfil()
        {
            CreateMap<Modell, ModellListeDüo>().ForMember(c=>c.MarkenName,opt=>opt.MapFrom(c=>c.Marke.Name)).ReverseMap();
            CreateMap<IPaginierung<Modell>, ModellListeModell>().ReverseMap();
            
        }
    }
}
