using Microsoft.Extensions.Logging;

namespace mod06
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Font Awesome 6 Free-Regular-400.otf", "FA6FR");
                    fonts.AddFont("Font Awesome 6 Free-Solid-900.otf", "FA6FS");
                    fonts.AddFont("Font Awesome 6 Brands-Regular-400.otf", "FA6BR");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
