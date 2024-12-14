using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MWeatherApp.MVVM.ViewModels.Base;
using MWeatherApp.MVVM.Views;
using MWeatherApp.Service;
using System.ComponentModel;

namespace MWeatherApp.MVVM.ViewModels
{
    public partial class WelcomeViewModel(SharedService sharedService, KeyService keyService) : BaseViewModel
    {
        private readonly SharedService _sharedService = sharedService;
        private readonly KeyService _keyService = keyService;

        [ObservableProperty]
        private string? cityName;

        [ObservableProperty]
        private string? aPIKey;

        [ObservableProperty]
        private bool isSubmitButtonEnabled = false;


        partial void OnCityNameChanged(string? value)
        {
            if (CityName != null && CityName.Length > 2)
            {
                IsSubmitButtonEnabled = true;
            }
            else
            {
                IsSubmitButtonEnabled = false;
            }
        }

        [RelayCommand]
        private async Task SaveKey()
        {
            await _keyService.SaveTokenAsync(APIKey);
        }

        [RelayCommand]
        private async Task GetWeather()
        {
            _sharedService.InitializeAppShell();
            await Shell.Current.GoToAsync($"///{nameof(HomePage)}?CityName={CityName}", true);

        }
    }
}
