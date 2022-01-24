using System.Collections.Specialized;
using System.Threading.Tasks;

namespace DesafioWebmotors.DesafioOnline
{
    public interface IDesafioOnlineApi
    {
        Task<T> GetAsync<T>(string routeController, NameValueCollection query);

        Task<T> PostAsync<T, Y>(string routeController, Y content, NameValueCollection query);

        Task<T> PutAsync<T, Y>(string routeController, Y content, NameValueCollection query);

        Task<T> DeleteAsync<T>(string routeController, NameValueCollection query);
    }
}
