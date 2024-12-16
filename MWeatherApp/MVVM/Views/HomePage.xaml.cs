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


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is HomeViewModel viewModel)
            {
                await viewModel.InitializeAsync();
            }
        }
    }
}
