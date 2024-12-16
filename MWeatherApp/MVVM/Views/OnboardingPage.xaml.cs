using MWeatherApp.MVVM.ViewModels;

namespace MWeatherApp.MVVM.Views
{
    public partial class OnboardingPage : ContentPage
    {
        public OnboardingPage(OnboardingViewModel onboardingViewModel)
        {
            InitializeComponent();
            BindingContext = onboardingViewModel;
        }
    }
}
