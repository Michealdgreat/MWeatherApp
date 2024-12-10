using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MWeatherApp.MVVM.ViewModels;
using MWeatherApp.MVVM.Views;
using MWeatherApp.Service;

namespace MWeatherApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Interlight.ttf", "Interlight");
                    fonts.AddFont("Intermedium.ttf", "Intermedium");
                    fonts.AddFont("Interregular.ttf", "Interregular");
                    fonts.AddFont("Interthin.ttf", "Interthin");

                });


            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<WelcomePage>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<WelcomeViewModel>();

            builder.Services.AddSingleton<GetService>();
            builder.Services.AddSingleton<KeyService>();





#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
