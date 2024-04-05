using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using ToDoApp.Views;

namespace ToDoApp.ViewModels;

public partial class ProfilesViewModel : ObservableObject
{
	[ObservableProperty] private ObservableCollection<Profile> _profiles;

	public ProfilesViewModel()
	{
		_profiles = new ObservableCollection<Profile>();
	}

	public void AddProfile(string profileName)
	{
		Profile profile = new Profile { ID = Profiles.Count, Name = profileName };
        Profiles.Add(profile);
	}

    [RelayCommand]
    private void RemoveProfile(int id)
    {
        for (int i = 0; i < Profiles.Count; i++)
		{
			if (Profiles[i].ID == id)
			{
				Profiles.RemoveAt(i);
				return;
			}
		}
    }

	[RelayCommand]
	private async System.Threading.Tasks.Task OpenProfile(int profileID)
	{
		for (int i = 0; i < Profiles.Count; i++)
		{
			if (Profiles[i].ID == profileID)
			{

				await Shell.Current.GoToAsync(nameof(TaskListPage), new Dictionary<string, object>
				{
					{ "profile", Profiles[i] }
                });

                break;
            }
        }
	}
}

[Serializable]
public class Profile
{
	public int ID { get; set; }
	public string Name { get; set; } = string.Empty;

	public List<Task> Tasks { get; set; } = new List<Task>();
}