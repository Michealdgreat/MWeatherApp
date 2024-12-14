using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MWeatherApp.MVVM.ViewModels;
using MWeatherApp.MVVM.Views;
using MWeatherApp.Service;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System.Reflection;

namespace MWeatherApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();


            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("MWeatherApp.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build();

            // Add configuration to services
            builder.Configuration.AddConfiguration(config);

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Interlight.ttf", "Interlight");
                    fonts.AddFont("Intermedium.ttf", "Intermedium");
                    fonts.AddFont("Interregular.ttf", "Interregular");
                    fonts.AddFont("Interthin.ttf", "Interthin");
                    fonts.AddFont("Interextralight.ttf", "Interextralight");
                    fonts.AddFont("mweatherapp.ttf", "mweatherappicons");
                    fonts.AddFont("Interthinnew.ttf", "Interthinnew");
                });

            // Register your services and viewmodels
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<WelcomePage>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<WelcomeViewModel>();

            builder.Services.AddSingleton<GetService>();
            builder.Services.AddSingleton<KeyService>();
            builder.Services.AddSingleton<SharedService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}