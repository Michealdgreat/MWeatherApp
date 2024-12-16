using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MWeatherApp.MVVM.Models;
using MWeatherApp.MVVM.ViewModels.Base;
using MWeatherApp.MVVM.Views;
using MWeatherApp.Service;
using System.ComponentModel;

namespace MWeatherApp.MVVM.ViewModels
{

    [QueryProperty(nameof(OpenApiErrorMessage), "OpenApiErrorMessage")]

    public partial class WelcomeViewModel : BaseViewModel
    {
        private readonly SharedService _sharedService;
        private readonly KeyService _keyService;
        private readonly GetService _getService;
        [ObservableProperty]
        private string? cityName;

        [ObservableProperty]
        private string? aPIKey;

        [ObservableProperty]
        private string? openAPIKey;

        [ObservableProperty]
        private string? openApiSavedButton = "Save";

        [ObservableProperty]
        public string? openApiErrorMessage;

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
        private bool weatherInformationLoading = false;

        [ObservableProperty]
        private bool controlArea = true;

        [ObservableProperty]
        private string settingsButtonText = "Open Settings";

        public WelcomeViewModel(SharedService sharedService, KeyService keyService, GetService getService)
        {
            _sharedService = sharedService;
            _keyService = keyService;
            _getService = getService;
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
                OpenApiErrorMessage = string.Empty;
            }
            else
            {
                SettingButtonLabel = true;
                SettingGearicon = false;
                GetWeatherCommandArea = false;
                OpenSettingVisible = true;
                SettingsButtonText = "Close Settings";
                OpenApiErrorMessage = string.Empty;
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

            try
            {
                WeatherInformationLoading = true;
                ControlArea = false;

                bool checkkeys = await CheckApiKeys();
                bool checkapiconnection = await CheckApiConnection();

                if (!checkkeys)
                {

                    OpenApiErrorMessage = "API Key not found!";
                    WeatherInformationLoading = false;
                    ControlArea = true;

                }

                if (!checkapiconnection)
                {

                    OpenApiErrorMessage = $"Error retrieving the weather data for {CityName}. Please verify the spelling and try again.";
                    WeatherInformationLoading = false;
                    ControlArea = true;

                }
                else
                {
                    WeatherInformationLoading = false;
                    ControlArea = true;
                    await Shell.Current.GoToAsync($"{nameof(HomePage)}?CityName={CityName}", true);
                }




            }
            catch (Exception)
            {

                OpenApiErrorMessage = "Something went wrong";
                WeatherInformationLoading = false;
                ControlArea = true;

            }

        }
        private async Task<bool> CheckApiConnection()
        {
            var result = await _getService.GetCityDetails<LocationModel>(EndPoints.cityDetail, CityName);

            if (result != null)
            {
                return true;
            }

            return false;
        }

        private async Task<bool> CheckApiKeys()
        {
            var checkopenapi = await _keyService.GetTokenAsync("Open_api_key");
            var checkweatherapi = await _keyService.GetTokenAsync("api_key");

            if (checkopenapi == null || checkweatherapi == null)
            {

                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
