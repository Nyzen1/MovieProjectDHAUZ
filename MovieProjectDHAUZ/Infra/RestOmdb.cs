using Newtonsoft.Json;
using RestSharp;

namespace MovieProjectDHAUZ.Infra
{
    public class RestOmdb
    {
        private RestClient _client;
        private const string _key = "98d2924d";
        public RestOmdb(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("rota base não pode ser nula ou vazia.");

            if (_client is null)
                _client = new RestClient(baseUrl);
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
