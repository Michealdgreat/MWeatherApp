using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MWeatherApp.MVVM.ViewModels;
using MWeatherApp.MVVM.Views;
using Xe.AcrylicView;
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

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseAcrylicView()
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
                    fonts.AddFont("mweatherappfonts.ttf", "mweatherappfonts");
                    fonts.AddFont("Interthinnew.ttf", "Interthinnew");
                    fonts.AddFont("Rubik-Black.ttf", "RubikBlack");
                    fonts.AddFont("Rubik-BlackItalic.ttf", "RubikBlackItalic");
                    fonts.AddFont("Rubik-Bold.ttf", "RubikBold");
                    fonts.AddFont("Rubik-BoldItalic.ttf", "RubikBoldItalic");
                    fonts.AddFont("Rubik-ExtraBold.ttf", "RubikExtraBold");
                    fonts.AddFont("Rubik-ExtraBoldItalic.ttf", "RubikExtraBoldItalic");
                    fonts.AddFont("Rubik-Italic.ttf", "RubikItalic");
                    fonts.AddFont("Rubik-Light.ttf", "RubikLight");
                    fonts.AddFont("Rubik-LightItalic.ttf", "RubikLightItalic");
                    fonts.AddFont("Rubik-Medium.ttf", "RubikMedium");
                    fonts.AddFont("Rubik-MediumItalic.ttf", "RubikMediumItalic");
                    fonts.AddFont("Rubik-Regular.ttf", "RubikRegular");
                    fonts.AddFont("Rubik-SemiBold.ttf", "RubikSemiBold");
                    fonts.AddFont("Rubik-SemiBoldItalic.ttf", "RubikSemiBoldItalic");
                });


            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<WelcomePage>();

            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<WelcomeViewModel>();

            builder.Services.AddSingleton<GetService>();
            builder.Services.AddSingleton<KeyService>();
            builder.Services.AddSingleton<SharedService>();
            builder.Services.AddSingleton<OpenAIService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}