using Newtonsoft.Json;
using RestSharp;

namespace MovieProjectDHAUZ.Infra
{
    public class RestOmdb
    {
        private RestClient _client;
        private readonly string _key;
        public RestOmdb(string baseUrl, string key)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("rota base não pode ser nula ou vazia.");

            if (_client is null)
                _client = new RestClient(baseUrl);

            _key = key;
        }

        public async Task<T> GetAsync<T>(string route)
        {
            route += $"&apikey={_key}";

            var request = new RestRequest(route);
            var result = await _client.ExecuteAsync(request);

            if (result.IsSuccessful && !string.IsNullOrEmpty(result.Content))
                return JsonConvert.DeserializeObject<T>(result.Content);

            return default;
        }
    }
}
