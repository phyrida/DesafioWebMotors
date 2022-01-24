using AutoMapper;
using DesafioWebMotors.Domain.Dto;
using DesafioWebMotors.Domain.Entities;
using DesafioWebMotors.Domain.Interfaces;
using DesafioWebMotors.Domain.Interfaces.Services;
using FluentValidation;

namespace DesafioWebMotors.Service.Services
{
    public  class AnuncioWebmotorsService
        : ServiceBase<AnuncioWebmotorsEntity, AnuncioWebmotorsDtoCreate, AnuncioWebmotorsDto, AnuncioWebmotorsDtoUpdate>, IAnuncioWebmotorsService
    {
        private readonly IBaseRepository<AnuncioWebmotorsEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<AnuncioWebmotorsDto> _validator;

        public AnuncioWebmotorsService(IBaseRepository<AnuncioWebmotorsEntity> repository, IMapper mapper, IValidator<AnuncioWebmotorsDto> validator)
            : base(repository, mapper, validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }
    }
}
