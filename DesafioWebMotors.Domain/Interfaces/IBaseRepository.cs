using DesafioWebMotors.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DesafioWebMotors.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);

        Task<T> UpdateAsync(T item);

        Task<bool> DeleteAsync(long id);

        Task<T> SelectAsync(long id);

        Task<IEnumerable<T>> SelectAsync(int page, int count);

        Task<T> SelectOneAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> SelectListAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> SelectActivesAsync(int page, int count);
    }
}
