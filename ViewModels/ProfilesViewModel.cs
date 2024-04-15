using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.Views;

namespace ToDoApp.ViewModels;

public partial class ProfilesViewModel : BaseViewModel
{
    private ProfilesService _profilesService;

    private ObservableCollection<Profile>? _profiles = new();

    public ObservableCollection<Profile>? Profiles => _profiles;

    public ProfilesViewModel(ProfilesService service)
    {
        _profilesService = service;
        LoadProfiles();
    }

    public void AddProfile(string profileName)
    {
        Profile profile = new Profile { ID = Profiles?.Count ?? 0, Name = profileName };
        Profiles?.Add(profile);
    }

    [RelayCommand]
    private void RemoveProfile(int id)
    {
        for (int i = 0; i < Profiles?.Count; i++)
        {
            if (Profiles[i].ID == id)
            {
                Profiles.RemoveAt(i);
                return;
            }
        }
    }

    private void LoadProfiles()
    {
        try
        {
            List<Profile> profiles = _profilesService.GetProfiles();

            Profiles?.Clear();
            for (int i = 0; i < profiles.Count; i++)
            {
                Profiles?.Add(profiles[i]);
            }
        }
        catch (Exception ex)
        {
            Shell.Current.DisplayAlert("Error!", $"Unable to get profiles: {ex.Message}", "OK");
        }
    }


    [RelayCommand]
    private async Task OpenProfile(int profileID)
    {
        for (int i = 0; i < Profiles?.Count; i++)
        {
            if (Profiles[i].ID == profileID)
            {
                await Shell.Current.GoToAsync(nameof(TasksPage), new Dictionary<string, object> { { "profile", Profiles[i] } });
                break;
            }
        }
    }
}