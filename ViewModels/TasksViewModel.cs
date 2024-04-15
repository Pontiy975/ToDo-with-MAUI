using CommunityToolkit.Mvvm.Input;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public partial class TasksViewModel : BaseViewModel, IQueryAttributable
    {
        private Profile? _currentProfile;

        public Profile? CurrentProfile
        {
            get => _currentProfile;
            set => SetProperty(ref _currentProfile, value);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            CurrentProfile = (Profile)query["profile"];
        }

        public void AddTask(string title)
        {
            ToDoTask task = new ToDoTask { ID = CurrentProfile?.Tasks.Count ?? 0, Title = title };
            CurrentProfile?.Tasks.Add(task);
        }

        [RelayCommand]
        private void RemoveTask(int id)
        {
            for (int i = 0; i < CurrentProfile?.Tasks?.Count; i++)
            {
                if (CurrentProfile.Tasks[i].ID == id)
                {
                    CurrentProfile.Tasks.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
