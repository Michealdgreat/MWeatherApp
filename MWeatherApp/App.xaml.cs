using MWeatherApp.MVVM.ViewModels;
using MWeatherApp.MVVM.Views;
using MWeatherApp.Service;

namespace MWeatherApp
{
    public partial class App : Application
    {
        private readonly WelcomeViewModel _welcomeViewModel;

        public App(WelcomeViewModel welcomeViewModel)
        {
            InitializeComponent();

            #region FORM HELPER
            // Borderless editor
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(EntryHelper), (handler, view) =>
            {
                if (view is EntryHelper)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                    handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif __WINDOWS__
                    handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
                    handler.PlatformView.BorderThickness = new Microsoft.Maui.Graphics.MauiThickness(0);
#endif
                }
            });


            _welcomeViewModel = welcomeViewModel;

            #endregion
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}