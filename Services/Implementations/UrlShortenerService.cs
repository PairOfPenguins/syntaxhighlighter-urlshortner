
using System.Text;
using System.Text.Json;

namespace pet2.Services.Implementations
{
    public class UrlShortenerService : IUrlShortenerService
    {
        public readonly string apiUrl = "https://smolurl.com/api/links";

        public readonly IHttpClientFactory _httpClientFactory;
        public UrlShortenerService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> ShortenUrlAsync(string longUrl)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = $"{{\"url\": \"{longUrl}\"}}";

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                string result = await response.Content.ReadAsStringAsync();

                var jsonDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(result);

                var data = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonDictionary["data"].ToString());

                string shortUrl = data["short_url"].ToString();

                return shortUrl;
            }
            catch (HttpRequestException e)
            {
                
                Console.WriteLine(e.ToString());
                return "error";
            }
        }
    }
}
