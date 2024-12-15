
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MWeatherApp.MVVM.Models;
using MWeatherApp.MVVM.ViewModels.Base;
using MWeatherApp.Service;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MWeatherApp.MVVM.ViewModels
{
    [QueryProperty(nameof(CityName), "CityName")]
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly GetService _getService;
        private readonly KeyService _keyService;
        private readonly OpenAIService _openAIService;
        [ObservableProperty]
        private LocationModel? cityDetails;

        [ObservableProperty]
        private ObservableCollection<WeatherForecastModel>? forecastModels;

        [ObservableProperty]
        private OneLocation? oneLocation;

        [ObservableProperty]
        private string? cityName;

        [ObservableProperty]
        private string? cityId;

        [ObservableProperty]
        private string? cityDescription;

        public HomeViewModel(GetService getService, KeyService keyService, OpenAIService openAIService)
        {
            ForecastModels = [];
            _getService = getService;
            _keyService = keyService;
            _openAIService = openAIService;
        }

        public async Task InitializeAsync()
        {
            // _keyService.DeleteToken();

            if (!string.IsNullOrEmpty(CityName))
            {
                await GetCity();

                CityDescription = await _openAIService.GetCityDescription(CityName);

            }
        }

        private async Task GetCity()
        {
            if (string.IsNullOrEmpty(CityName)) return;

            CityDetails = await _getService.GetCityDetails<LocationModel>(EndPoints.cityDetail, CityName);
            await GetCityWeather();
        }

        private async Task GetCityWeather()
        {
            if (CityDetails?.Key == null) return;

            OneLocation = await _getService.GetCityWeather<OneLocation>(EndPoints.cityWeather, CityDetails.Key);
            await GetCityForecast();
        }

        private async Task GetCityForecast()
        {
            if (CityDetails?.Key == null) return;

            var result = await _getService.GetListOfForecast<WeatherForecastModel>(EndPoints.forecastENdpoint, CityDetails.Key);

            ForecastModels = result;
        }


    }
}