using Microsoft.Extensions.Caching.Memory;

namespace PaginaEEST1.Services
{
    public class KickService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;

        public KickService(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _cache = cache;
        }

        public async Task<bool> IsChannelLiveAsync(string channelName)
        {
            if (_cache.TryGetValue(channelName, out bool isLive))
            {
                return isLive;
            }

            var apiKey = _configuration["KickApiKey"];
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://kick-com-api.p.rapidapi.com/livestream/{channelName}/status");
            request.Headers.Add("X-RapidAPI-Key", apiKey);
            request.Headers.Add("X-RapidAPI-Host", "kick-com-api.p.rapidapi.com");

            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)); // Timeout de 3 segundos

            try
            {
                var response = await _httpClient.SendAsync(request, cts.Token);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    isLive = content.Contains("\"isBroadcasting\":true");

                    // Guardar el resultado en caché por 15 minutos
                    _cache.Set(channelName, isLive, TimeSpan.FromMinutes(15));

                    return isLive;
                }
            }
            catch (TaskCanceledException)
            {
                // La solicitud fue cancelada debido al timeout
            }

            return false;
        }
    }
}
