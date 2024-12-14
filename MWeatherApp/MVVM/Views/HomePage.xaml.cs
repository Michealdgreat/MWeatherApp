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

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (BindingContext is HomeViewModel viewModel)
            {
                await viewModel.InitializeAsync();
            }
        }
    }
}
