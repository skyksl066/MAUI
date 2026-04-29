using Microsoft.Extensions.Logging;
using mod09.Services;
using mod09.ViewModels;
using mod09.Views;

namespace mod09
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

            builder.Services.AddTransient<TimeViewModel>();
            builder.Services.AddTransient<TimeView>();

            builder.Services.AddSingleton<IPetService, PetService>();

            builder.Services.AddSingleton<PetListViewModel>();
            builder.Services.AddSingleton<PetListView>();

            builder.Services.AddTransient<PetViewModel>();
            builder.Services.AddTransient<PetView>();

            return builder.Build();
        }
    }
}
