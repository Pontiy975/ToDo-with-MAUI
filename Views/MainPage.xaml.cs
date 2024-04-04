using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void DisplayPrompt(object sender, EventArgs e)
        {
            string task = await DisplayPromptAsync("Create task", "Enter the task");
            
            if (task is null || string.IsNullOrEmpty(task))
                return;

            ((MainViewModel)BindingContext).AddTask(task);
        }
    }

}
