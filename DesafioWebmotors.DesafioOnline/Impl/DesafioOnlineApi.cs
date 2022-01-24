﻿using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesafioWebmotors.DesafioOnline.Impl
{
    public class DesafioOnlineApi : IDesafioOnlineApi
    {
        public Task<T> DeleteAsync<T>(string routeController, NameValueCollection query)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync<T>(string routeController, NameValueCollection query)
        {
            using var clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                var response = await client.GetAsync($"{routeController}?{query}");
                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                var responseObj = System.Text.Json.JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                var responseObjNewton = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                return responseObj;
            }

        }

        public async Task<T> PostAsync<T, Y>(string routeController, Y content, NameValueCollection query)
        {

            using var clientHandler = new System.Net.Http.HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                var response = await client.PostAsync(routeController, new StringContent(System.Text.Json.JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"));

                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                var objResponse = await response.Content.ReadAsStringAsync();
                var responseObj = System.Text.Json.JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                var responseObjNewton = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

                return responseObj;
            }
        }

        public async Task<T> PutAsync<T, Y>(string routeController, Y content, NameValueCollection query)
        {
            using var clientHandler = new System.Net.Http.HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            using (var client = new HttpClient(clientHandler))
            {
                var response = await client.PutAsync(routeController, new StringContent(System.Text.Json.JsonSerializer.Serialize(content), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    throw new Exception(await response.Content.ReadAsStringAsync());

                var responseObj = System.Text.Json.JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
                var responseObjNewton = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

                return responseObj;
            }
        }
    }
}
