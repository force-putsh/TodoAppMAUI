using Microsoft.Extensions.Logging;
using TodoAppMAUI.Services;
using TodoAppMAUI.ViewModels;

namespace TodoAppMAUI
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
                    fonts.AddFont("OpenSans-Regular.ttf","OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf","OpenSansSemibold");
                });

            builder.Services.AddHttpClient(nameof(TodoService),client =>
            {
                client.BaseAddress = new("https://25pmvkhz-5179.uks1.devtunnels.ms");
            });
            builder.Services.AddSingleton<ITodoService,TodoService>();
            builder.Services.AddTransient<MainPage>().AddTransient<TodoViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
