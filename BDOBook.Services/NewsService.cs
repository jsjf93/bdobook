using BDOBook.Services.Interfaces;
using BDOBook.Services.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace BDOBook.Services
{
    public class NewsService : INewsService
    {
        private const string HttpClientName = nameof(NewsService);

        private readonly string _apiToken;
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsService(string apiToken, IHttpClientFactory httpClientFactory)
        {
            if (string.IsNullOrEmpty(apiToken))
            {
                throw new ArgumentException("API token cannot be null or empty", nameof(apiToken));
            }

            _apiToken = apiToken;
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<GetMostRecentResponse> GetMostRecent()
        {
            var client = _httpClientFactory.CreateClient(HttpClientName);

            try
            {
                var response = await client.GetFromJsonAsync<GetMostRecentResponse>(
                    $"top?api_token={_apiToken}&categories=tech&locale=gb&limit=3",
                    new JsonSerializerOptions(JsonSerializerDefaults.Web));

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
