using DesafioWebMotors.Domain.Dto.DesafioOnline;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioWebmotors.DesafioOnline
{
    public interface IDesafioOnlineClient
    {
        Task<IEnumerable<MakeDto>> GetMakeAsync();

        Task<IEnumerable<ModelDto>> GetModelAsync(int makeId);

        Task<IEnumerable<VersionDto>> GetVersionAsync(int modelId);

        Task<IEnumerable<VehicleDto>> GetVehicleAsync(int page);
    }
}
