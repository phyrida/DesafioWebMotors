using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioWebMotors.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, Create, Read, Update>
    {
        Task<Read> GetAsync(long id);

        Task<IEnumerable<Read>> GetAllAsync(int page, int count);

        Task<IEnumerable<Read>> GetAllAsync();

        Task<Read> PostAsync(Create user);

        Task<Read> PutAsync(Update user);

        Task<bool> DeleteAsync(long id);
    }
}
