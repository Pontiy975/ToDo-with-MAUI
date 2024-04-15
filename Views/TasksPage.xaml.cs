using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
	public partial class TasksPage : ContentPage
	{
		public TasksPage(TasksViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}

        private async void DisplayPrompt(object sender, EventArgs e)
        {
            string taskTitle = await DisplayPromptAsync("Create task", "Enter the task");

            if (taskTitle is null || string.IsNullOrEmpty(taskTitle))
                return;

            ((TasksViewModel)BindingContext).AddTask(taskTitle);
        }
    }
}