using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore
{
    public class RequestService
    {


        public async Task<T> GetAsync<T>( string uri)
        {
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(uri);

            await HandleResponse(response);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }
        public  Task<T> PostAsync<T>(string uri, T obj)
        {
            return PostAsync<T, T>(uri, obj);
        }

        public async Task<TResult> PostAsync<TRequest,TResult>(string uri, TRequest obj)
        {
            var client = new HttpClient();

            var requestJson = JsonConvert.SerializeObject(obj);

            var requestContent = new StringContent(requestJson, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(uri, requestContent);

            await HandleResponse(response);

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(content);
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new ApplicationException($"{response.StatusCode.ToString()} - {content}");
            }
        }
    }
}
