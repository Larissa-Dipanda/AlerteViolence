using Microsoft.Extensions.Logging;

namespace AlerteViolence; 

public static class MauiProgram{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("InstrumentSans-Regular.ttf", "InstrumentSansRegular");
                fonts.AddFont("InstrumentSans-SemiBold.ttf", "InstrumentSansSemiBold");
                fonts.AddFont("IstokWeb-Regular.ttf", "IstokWebRegular");
                fonts.AddFont("IstokWeb-Bold.ttf", "IstokWebBold");
            });

        return builder.Build();
    }
}