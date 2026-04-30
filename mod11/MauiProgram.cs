using Microsoft.Extensions.Logging;
using mod11.Services;
using mod11.ViewModels;
using mod11.Views;

namespace mod11
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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IPetService, PetServiceFormWeb>();

            builder.Services.AddSingleton<PetListViewModel>();
            builder.Services.AddSingleton<PetListView>();

            builder.Services.AddTransient<PetViewModel>();
            builder.Services.AddTransient<PetView>();

            return builder.Build();
        }
    }
}
