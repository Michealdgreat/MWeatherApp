using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MWeatherApp.MVVM.Models;
using MWeatherApp.MVVM.ViewModels.Base;
using MWeatherApp.Service;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MWeatherApp.MVVM.ViewModels
{
    public partial class HomeViewModel(GetService getService) : BaseViewModel
    {
        private readonly GetService _getService = getService;


        [ObservableProperty]
        private LocationModel? locationModel;

        [ObservableProperty]
        private List<WeatherForecastModel>? forecastModels;

        [ObservableProperty]
        private OneLocation? oneLocation;

        [ObservableProperty]
        private string? cityName;

        [ObservableProperty]
        private string? cityId;


        [RelayCommand]
        private async Task GetCity()
        {

            LocationModel = await _getService.GetCityDetails<LocationModel>(EndPoints.cityDetail, CityName);

        }

        [RelayCommand]
        private async Task GetCityWeather()
        {

            OneLocation = await _getService.GetCityWeather<OneLocation>(EndPoints.cityWeather, CityId);
        }

        [RelayCommand]
        private async Task GetCityForecast()
        {

            ForecastModels = await _getService.GetListOfForecast<WeatherForecastModel>(EndPoints.forecastENdpoint, CityId);
        }

    }
}
