using MWeatherApp.MVVM.Views;

namespace MWeatherApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));

        }
    }
}
