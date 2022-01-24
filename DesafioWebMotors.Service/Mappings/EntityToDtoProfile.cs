using AutoMapper;
using DesafioWebMotors.Domain.Dto;
using DesafioWebMotors.Domain.Entities;

namespace DesafioWebMotors.Service.Mappings
{
    public class EntityToDtoProfile:Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<AnuncioWebmotorsEntity, AnuncioWebmotorsDto>().ReverseMap();
            CreateMap<AnuncioWebmotorsEntity, AnuncioWebmotorsDtoCreate>().ReverseMap();
            CreateMap<AnuncioWebmotorsEntity, AnuncioWebmotorsDtoUpdate>().ReverseMap();
        }
    }
}
