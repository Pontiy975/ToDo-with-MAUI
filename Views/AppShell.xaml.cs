using ToDoApp.Views;

namespace ToDoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProfilesPage), typeof(ProfilesPage));
            Routing.RegisterRoute(nameof(TasksPage), typeof(TasksPage));
        }
    }
}
