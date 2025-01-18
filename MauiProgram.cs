using ExpenseBuddyJenish.Models;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace ExpenseBuddyJenish
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddMudServices();
            builder.Logging.AddDebug();
#endif



            
            builder.Services.AddMudServices();

           
            builder.Services.AddSingleton<DatabaseService>(serviceProvider =>
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
                return new DatabaseService(dbPath);
            });

            builder.Services.AddSingleton<TransactionService>(s =>
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "AppDatabase.db");
                return new TransactionService(dbPath);
            });


            return builder.Build();
        }
    }
}
