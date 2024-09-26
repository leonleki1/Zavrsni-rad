using AutoMapper;
using WebApiPaulovnija.DTO;

using WebApiPaulovnija.Controllers.Models;

namespace WebApiPaulovnija.DTO;
public class RadnikProfile : Profile
{
    public RadnikProfile()
    {
        CreateMap<Radnik, RadnikDto>();
        CreateMap<KreirajRadnika, Radnik>();
        CreateMap<AzurirajRadnika, Radnik>();
    }
}