using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
	public partial class ProfilesPage : ContentPage
	{
		public ProfilesPage(ProfilesViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}

        private async void DisplayPrompt(object sender, EventArgs e)
        {
            string profileName = await DisplayPromptAsync("Create profile", "Enter the name");

            if (profileName is null || string.IsNullOrEmpty(profileName))
                return;

            ((ProfilesViewModel)BindingContext).AddProfile(profileName);
        }

        private void ClearProfiles(object sender, EventArgs e)
        {
            ((ProfilesViewModel)BindingContext).ClearProfiles();
        }
    }
}