using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToDoApp.ViewModels;

[QueryProperty("CurrentProfile", "profile")]
public partial class TaskListViewModel : ObservableObject
{
	[ObservableProperty] private Profile? _currentProfile;

	public void AddTask(string task)
	{
		CurrentProfile?.Tasks.Add(new Task { Text = task });
	}

	[RelayCommand]
	public void RemoveTask(int id)
	{
		if (CurrentProfile == null) return;

		for (int i = 0; i < CurrentProfile.Tasks.Count; i++)
		{
			if (CurrentProfile.Tasks[i].ID == id)
			{
                CurrentProfile.Tasks.RemoveAt(i);
				return;
			}
		}
	}
}

[Serializable]
public class Task
{
	public int ID { get; set; }
	public string Text { get; set; } = string.Empty;
}