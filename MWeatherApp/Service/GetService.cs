using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MWeatherApp.Service
{
    public class GetService(KeyService keyService)
    {
        private readonly KeyService _keyService = keyService;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<ObservableCollection<T>?> GetListOfForecast<T>(string endPoint, string cityId)
        {
            try
            {
                var apiKey = await _keyService.GetTokenAsync();
                using var client = new HttpClient();
                var url = $"{endPoint}{cityId}?apikey={apiKey}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ObservableCollection<T>>(responseData, JsonSerializerOptions);
                }
                else
                {
                    return default;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<T?> GetCityDetails<T>(string endPoint, string query)
        {
            try
            {


                var apiKey = await _keyService.GetTokenAsync();
                string url = $"{endPoint}search?apiKey={apiKey}&q={query}";
                using var client = new HttpClient();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(responseData, JsonSerializerOptions);
                }
                else
                {

                    return default;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        public async Task<T?> GetCityWeather<T>(string endPoint, string query)
        {
            try
            {

                var apiKey = await _keyService.GetTokenAsync();
                using var client = new HttpClient();
                var url = $"{endPoint}{query}?apikey={apiKey}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<T>(responseData, JsonSerializerOptions);
                }
                else
                {

                    return default;
                }
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}