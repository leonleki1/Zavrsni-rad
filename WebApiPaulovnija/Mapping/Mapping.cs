using AutoMapper;
using WebApiPaulovnija.DTO;
using WebApiPaulovnija.Models;

namespace WebApiPaulovnija.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Radnik, RadnikDTO>().ReverseMap();
            CreateMap<KreirajRadnikaDTO, Radnik>();
            CreateMap<AzurirajRadnikaDTO, Radnik>();
            CreateMap<Rasadnik, RasadnikDTO>().ReverseMap();
            CreateMap<KreirajRasadnikDTO, RasadnikDTO>();
            CreateMap<AzurirajRasadnikDTO, RasadnikDTO>();
            CreateMap<Zadatak, ZadatakDTO>().ReverseMap();
            CreateMap<KreirajZadatakDTO, Zadatak>();
            CreateMap<AzurirajZadatakDTO, Zadatak>();
            CreateMap<Sadnica, SadnicaDTO>().ReverseMap();
            CreateMap<KreirajSadnicuDTO, SadnicaDTO>();
            CreateMap<AzurirajSadnicuDTO, SadnicaDTO>();
            CreateMap<Stroj, StrojDTO>().ReverseMap();
            CreateMap<KreirajStrojDTO, Stroj>();
            CreateMap<AzurirajStrojDTO, Stroj>();
        }
    }
}
