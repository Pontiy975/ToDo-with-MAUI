using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoApp.Views;

namespace ToDoApp
{
    public static class MauiProgram
    {
        private static MauiAppBuilder _builder = MauiApp.CreateBuilder();
        
        public static MauiApp CreateMauiApp()
        {
            _builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            _builder.Services.AddSingleton<ProfilesService>();
            _builder.Services.AddSingleton<ProfilesViewModel>();
            _builder.Services.AddSingleton<ProfilesPage>();

            _builder.Services.AddSingleton<TasksViewModel>();
            _builder.Services.AddSingleton<TasksPage>();

            return _builder.Build();
        }
    }
}
