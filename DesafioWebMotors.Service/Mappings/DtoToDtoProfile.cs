using AutoMapper;
using DesafioWebMotors.Domain.Dto;

namespace DesafioWebMotors.Service.Mappings
{
    public class DtoToDtoProfile : Profile
    {
        public DtoToDtoProfile()
        {
            CreateMap<AnuncioWebmotorsDto, AnuncioWebmotorsDtoCreate>().ReverseMap();
            CreateMap<AnuncioWebmotorsDto, AnuncioWebmotorsDtoUpdate>().ReverseMap();
            CreateMap<AnuncioWebmotorsDtoCreate, AnuncioWebmotorsDtoUpdate>().ReverseMap();
        }
    }
}
