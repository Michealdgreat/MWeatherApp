using MWeatherApp.MVVM.ViewModels;

namespace MWeatherApp.MVVM.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            BindingContext = homeViewModel;
        }
    }
}
