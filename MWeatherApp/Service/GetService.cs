
using MWeatherApp.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static MWeatherApp.MVVM.Models.DailyForecastModel;

namespace MWeatherApp.Service
{
    public class GetService(KeyService keyService)
    {
        private readonly KeyService _keyService = keyService;

        public async Task<ObservableCollection<T>?> GetListOfForecast<T>(string endPoint, string cityId)
        {
            try
            {
                var apiKey = await _keyService.GetTokenAsync("api_key");
                using var client = new HttpClient();
                var url = $"{endPoint}{cityId}?apikey={apiKey}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    ObservableCollection<T> forecasts = JsonConvert.DeserializeObject<ObservableCollection<T>>(responseData);


                    return forecasts;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception)
            {
                return default;
            }
        }

        public async Task<WeatherForecast?> GetDailyWeatherForecast(string endPoint, string cityId)
        {
            try
            {
                var apiKey = await _keyService.GetTokenAsync("api_key");
                using var client = new HttpClient();
                var url = $"{endPoint}{cityId}?apikey={apiKey}&language=en-us&details=false&metric=false";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    WeatherForecast forecast = JsonConvert.DeserializeObject<WeatherForecast>(responseData);

                    return forecast;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<T?> GetCityDetails<T>(string endPoint, string query)
        {
            try
            {

                var apiKey = await _keyService.GetTokenAsync("api_key");
                string url = $"{endPoint}{apiKey}&q={query}";
                using var client = new HttpClient();
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    try
                    {
                        var responseData = await response.Content.ReadAsStringAsync();

                        List<T> locations = JsonConvert.DeserializeObject<List<T>>(responseData);

                        var location = locations.FirstOrDefault();

                        if (location == null)
                        {
                            throw new Exception("No location data found.");
                        }

                        return location;

                    }
                    catch (Exception)
                    {

                        return default;
                    }

                }
                else
                {

                    return default;
                }
            }
            catch (Exception)
            {

                return default;
            }
        }

        public async Task<T?> GetCityWeather<T>(string endPoint, string query)
        {
            try
            {

                var apiKey = await _keyService.GetTokenAsync("api_key");
                using var client = new HttpClient();
                var url = $"{endPoint}{query}?apikey={apiKey}";
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<T>>(responseData).FirstOrDefault();

                    return result;
                }
                else
                {

                    return default;
                }
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}