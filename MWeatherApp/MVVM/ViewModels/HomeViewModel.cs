
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MWeatherApp.MVVM.Models;
using MWeatherApp.MVVM.ViewModels.Base;
using MWeatherApp.Service;
using System.Collections.ObjectModel;

namespace MWeatherApp.MVVM.ViewModels
{
    [QueryProperty(nameof(CityName), "CityName")]
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly GetService _getService;

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

        public HomeViewModel(GetService getService)
        {
            ForecastModels = new ObservableCollection<WeatherForecastModel>();
            _getService = getService;
        }

        public async Task InitializeAsync()
        {
            if (!string.IsNullOrEmpty(CityName))
            {
                await GetCity();
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