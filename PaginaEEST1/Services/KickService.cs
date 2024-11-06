  using Microsoft.Extensions.Caching.Memory;
using System;
using System.Text.Json;

namespace PaginaEEST1.Services
{
    public interface IKickService
    {
        Task<bool> IsChannelLiveAsync(string channelName);
    }

    public class KickApiResponse
    {
        public Data? Data { get; set; }
    }

    public class Data
    {
        public bool IsBroadcasting { get; set; }
    }

    public class KickService : IKickService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private readonly SemaphoreSlim _semaphore;

        private const string ApiHost = "kick-com-api.p.rapidapi.com";
        private const int CacheMinutes = 15;
        private const int TimeoutSeconds = 30;

        public KickService(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _semaphore = new SemaphoreSlim(1, 1);
        }

        public async Task<bool> IsChannelLiveAsync(string channelName)
        {
            // Se añadio esta verificación para evitar que se le pase un String vacio a la función
            if (string.IsNullOrEmpty(channelName))
            {
                throw new ArgumentException("Channel name cannot be null or empty", nameof(channelName));
            }

            var cacheKey = $"kick_channel_{channelName}";

            await _semaphore.WaitAsync();

            try
            {
                // Primero verifica el caché
                if (_cache.TryGetValue(cacheKey, out bool cachedStatus))
                {
                    return cachedStatus;
                }

                // Preparar la solicitud a la API
                var apiKey = _configuration["KickApiKey"]
                    ?? throw new InvalidOperationException("KickApiKey configuration is missing");


                using var request = new HttpRequestMessage(HttpMethod.Get,
                    $"https://{ApiHost}/livestream/{channelName}/status");
                request.Headers.Add("X-RapidAPI-Key", apiKey);
                request.Headers.Add("X-RapidAPI-Host", ApiHost);

                // Ejecutar la solicitud con tiempo de espera maximo
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TimeoutSeconds));
                using var response = await _httpClient.SendAsync(request, cts.Token);

                response.EnsureSuccessStatusCode();

                // Analizar respuesta (Parseo)
                var content = await response.Content.ReadAsStringAsync();
                var kickResponse = JsonSerializer.Deserialize<KickApiResponse>(content);
                var isLive = kickResponse?.Data?.IsBroadcasting ?? false;

                // Guardar el resultado en la Cache
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheMinutes));
                _cache.Set(cacheKey, isLive, cacheOptions);

                return isLive;
            }
            catch (Exception ex)
            {

                if(ex is HttpRequestException)
                    Console.WriteLine("La API ha vuelto a brillar por su incompetencia.");
                if(ex is TaskCanceledException)
                    Console.WriteLine("La API decidió tomarse un descanso... otra vez.");
                if (ex is JsonException)
                    Console.WriteLine("Parece que la API esta inventando su propio formato JSON... ¡genial!");
                else
                    Console.WriteLine("La API ya se esta inventado sus propios errores.");

                // En caso de error, guardar false en la caché
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(CacheMinutes));
                _cache.Set(cacheKey, false, cacheOptions);

                return false;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
