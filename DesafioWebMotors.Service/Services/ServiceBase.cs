using AutoMapper;
using DesafioWebMotors.Domain.Entities;
using DesafioWebMotors.Domain.Exceptions;
using DesafioWebMotors.Domain.Interfaces;
using DesafioWebMotors.Domain.Interfaces.Services;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebMotors.Service.Services
{
    public class ServiceBase<TEntity, Create, Read, Update> : IServiceBase<TEntity, Create, Read, Update> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<Read> _validator;

        public ServiceBase(IBaseRepository<TEntity> repository, IMapper mapper, IValidator<Read> validator)
        {
            _repository = repository;
            _mapper = mapper;
            _validator = validator;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Read>> GetAllAsync(int page, int count)
        {
            var result = await _repository.SelectAsync(page, count);
            return _mapper.Map<IEnumerable<Read>>(result);
        }

        public async Task<IEnumerable<Read>> GetAllAsync()
        {
            var result = await _repository.SelectListAsync(x => true);
            return _mapper.Map<IEnumerable<Read>>(result);
        }

        public async Task<Read> GetAsync(int id)
        {
            var result = await _repository.SelectAsync(id);
            return _mapper.Map<Read>(result);
        }

        public async Task<Read> PostAsync(Create entity)
        {
            _ = await CheckIsValid(_mapper.Map<Read>(entity));

            var entityMapped = _mapper.Map<TEntity>(entity);
            var result = await _repository.InsertAsync(entityMapped);
            return _mapper.Map<Read>(result);
        }

        public async Task<Read> PutAsync(Update entity)
        {
            _ = await CheckIsValid(_mapper.Map<Read>(entity));

            var entityMapped = _mapper.Map<TEntity>(entity);
            var result = await _repository.UpdateAsync(entityMapped);
            return _mapper.Map<Read>(result);
        }

        private async Task<bool> CheckIsValid(Read entity)
        {
            var resultValidation = _validator.Validate(entity);

            if (!resultValidation.IsValid)
                throw new BadRequestException(string.Join(',', resultValidation.Errors.Select(x => x.ErrorMessage)));

            return await Task.FromResult(true);
        }
    }
}
