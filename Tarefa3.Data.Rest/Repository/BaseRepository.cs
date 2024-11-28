using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Tarefa3.Data.Rest.Repository
{
    public class BaseRepository
    {
        private readonly RestClient _client;

        public BaseRepository(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<T> GetAsync<T>(string endpoint) where T : new()
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _client.ExecuteAsync<T>(request);

            if (!response.IsSuccessful || response.Data == null)
                throw new Exception($"Request failed: {response.ErrorMessage}");

            return response.Data;
        }
    }
}
