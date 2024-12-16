using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MWeatherApp.MVVM.ViewModels.Base;
using MWeatherApp.MVVM.Views;
using System.ComponentModel;

namespace MWeatherApp.MVVM.ViewModels
{
    public partial class OnboardingViewModel : BaseViewModel
    {


        [RelayCommand]
        private async Task GetStarted()
        {
            await Shell.Current.GoToAsync(nameof(WelcomePage), true);
        }
    }
}
