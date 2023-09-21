using Microsoft.Extensions.Logging;
using Example.WebComponents.Data;
using Example.WebComponents.Pages;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;

namespace Example.App;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => { fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        builder.Services.AddTransient<Login>();
        builder.Services.AddTransient<FetchData>();

        //Define routes for ShellContent pages

        Routing.RegisterRoute("/login", typeof(Login));
        Routing.RegisterRoute("/fetchdata", typeof(FetchData));

        return builder.Build();
    }
}
