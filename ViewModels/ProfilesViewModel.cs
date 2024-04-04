using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

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
		Profiles.Add(new Profile { ID = Profiles.Count, Name = profileName });
	}

    [RelayCommand]
    public void RemoveProfile(int id)
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
}

public class Profile
{
	public int ID { get; set; }
	public string Name { get; set; } = string.Empty;
}