using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MWeatherApp.MVVM.ViewModels.Base;
using MWeatherApp.MVVM.Views;
using MWeatherApp.Service;
using System.ComponentModel;

namespace MWeatherApp.MVVM.ViewModels
{
    public partial class WelcomeViewModel : BaseViewModel
    {
        private readonly SharedService _sharedService;
        private readonly KeyService _keyService;

        [ObservableProperty]
        private string? cityName;

        [ObservableProperty]
        private string? aPIKey;

        [ObservableProperty]
        private string? openAPIKey;

        [ObservableProperty]
        private string? openApiSavedButton = "Save";

        [ObservableProperty]
        private string? openApierrorMessage;

        [ObservableProperty]
        private string? weatherApierrorMessage;

        [ObservableProperty]
        private bool isSubmitButtonEnabled = false;

        [ObservableProperty]
        private bool getWeatherCommandArea = true;

        [ObservableProperty]
        private bool settingButtonLabel = false;

        [ObservableProperty]
        private bool settingGearicon = true;

        [ObservableProperty]
        private bool openSettingVisible = false;

        [ObservableProperty]
        private bool isKeySubmitButtonEnabled = false;

        [ObservableProperty]
        private bool isOpenKeySubmitButtonEnabled = false;

        [ObservableProperty]
        private bool hideApiKeyEntry = false;

        [ObservableProperty]
        private bool hideOpenApiKeyEntry = false;

        [ObservableProperty]
        private string settingsButtonText = "Open Settings";

        public WelcomeViewModel(SharedService sharedService, KeyService keyService)
        {
            _sharedService = sharedService;
            _keyService = keyService;

        }

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

        partial void OnAPIKeyChanged(string? value)
        {
            if (APIKey != null && APIKey.Length > 10)
            {
                IsKeySubmitButtonEnabled = true;
            }
            else
            {
                IsKeySubmitButtonEnabled = false;
            }
        }


        [RelayCommand]
        private void EnableSettings()
        {
            if (OpenSettingVisible == true)
            {
                OpenSettingVisible = false;
                SettingButtonLabel = false;
                GetWeatherCommandArea = true;
                SettingGearicon = true;
                SettingsButtonText = "Open Settings";
                OpenApierrorMessage = string.Empty;
            }
            else
            {
                SettingButtonLabel = true;
                SettingGearicon = false;
                GetWeatherCommandArea = false;
                OpenSettingVisible = true;
                SettingsButtonText = "Close Settings";
                OpenApierrorMessage = string.Empty;
            }
        }

        partial void OnOpenAPIKeyChanged(string? value)
        {
            if (OpenAPIKey != null && OpenAPIKey.Length > 10)
            {
                IsOpenKeySubmitButtonEnabled = true;
            }
            else
            {
                IsOpenKeySubmitButtonEnabled = false;
            }
        }

        [RelayCommand]
        private async Task SaveOpenKey()
        {

            if (OpenAPIKey != null)
            {
                await _keyService.SaveTokenAsync("Open_api_key", OpenAPIKey);

                HideOpenApiKeyEntry = true;
            }

        }

        [RelayCommand]
        private async Task SaveKey()
        {

            if (APIKey != null)
            {
                await _keyService.SaveTokenAsync("api_key", APIKey);

                HideApiKeyEntry = true;
            }

        }

        [RelayCommand]
        private async Task GetWeather()
        {
            bool checkkeys = await CheckApiKeys();

            if (checkkeys)
            {
                _sharedService.InitializeAppShell();
                await Shell.Current.GoToAsync($"///{nameof(HomePage)}?CityName={CityName}", true);
            }

        }

        private async Task<bool> CheckApiKeys()
        {
            var checkopenapi = await _keyService.GetTokenAsync("Open_api_key");
            var checkweatherapi = await _keyService.GetTokenAsync("api_key");

            if (checkopenapi == null || checkweatherapi == null)
            {
                OpenApierrorMessage = "Please Open settings below and Set your Weather and API key";

                return false;
            }
            else
            {
                return true;
            }


        }
    }
}
