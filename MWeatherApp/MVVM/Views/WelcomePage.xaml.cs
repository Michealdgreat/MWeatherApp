using MWeatherApp.MVVM.ViewModels;

namespace MWeatherApp.MVVM.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage(WelcomeViewModel welcomeViewModel)
        {
            InitializeComponent();
            BindingContext = welcomeViewModel;
        }
    }
}
