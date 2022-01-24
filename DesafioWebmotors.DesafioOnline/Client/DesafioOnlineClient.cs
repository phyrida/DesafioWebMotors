using DesafioWebMotors.Domain.Dto.DesafioOnline;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web;

namespace DesafioWebmotors.DesafioOnline.Client
{
    public class DesafioOnlineClient : IDesafioOnlineClient
    {
        private readonly IConfiguration _configuration;
        private readonly IDesafioOnlineApi _clientApi;
        private readonly string urlBase;

        private NameValueCollection query;

        public DesafioOnlineClient(IConfiguration configuration, IDesafioOnlineApi clientApi)
        {
            _clientApi = clientApi;
            _configuration = configuration;
            urlBase = _configuration["DesafioOnline:UrlBase"];

            query = HttpUtility.ParseQueryString(string.Empty);
        }

        public async Task<IEnumerable<MakeDto>> GetMakeAsync()
        {
            return await _clientApi.GetAsync<IEnumerable<MakeDto>>($"{urlBase}/Make", query);
        }

        public async Task<IEnumerable<ModelDto>> GetModelAsync(int makeId)
        {
            query.Add("MakeID", makeId.ToString());
            return await _clientApi.GetAsync<IEnumerable<ModelDto>>($"{urlBase}/Model", query);
        }

        public async Task<IEnumerable<VersionDto>> GetVersionAsync(int modelId)
        {
            query.Add("ModelID", modelId.ToString());
            return await _clientApi.GetAsync<IEnumerable<VersionDto>>($"{urlBase}/Version", query);
        }

        public async Task<IEnumerable<VehicleDto>> GetVehicleAsync(int page)
        {
            query.Add("page", page.ToString());
            return await _clientApi.GetAsync<IEnumerable<VehicleDto>>($"{urlBase}/Vehicles", query);
        }

        
    }
}
