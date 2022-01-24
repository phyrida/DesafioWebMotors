using DesafioWebMotors.Domain.Dto;
using DesafioWebMotors.Domain.Entities;

namespace DesafioWebMotors.Domain.Interfaces.Services
{
    public interface IAnuncioWebmotorsService : IServiceBase<AnuncioWebmotorsEntity, AnuncioWebmotorsDtoCreate, AnuncioWebmotorsDto, AnuncioWebmotorsDtoUpdate>
    {

    }
}
