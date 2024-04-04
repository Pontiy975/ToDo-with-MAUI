using CommunityToolkit.Mvvm.ComponentModel;
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


            InitPage<MainPage, MainViewModel>(_builder.Services.AddSingleton);
            InitPage<ProfilesPage, ProfilesViewModel>(_builder.Services.AddTransient);

            return _builder.Build();
        }

        private static void InitPage<T, S>(Func<Type, IServiceCollection> registerService)
            where T : ContentPage
            where S : ObservableObject
        {
            registerService(typeof(T));
            registerService(typeof(S));
        }
    }
}
