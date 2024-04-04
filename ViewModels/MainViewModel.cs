using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ToDoApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty] private ObservableCollection<string> _tasks;

	public MainViewModel()
	{
		_tasks = new ObservableCollection<string>();
	}

	public void AddTask(string task)
	{
		Tasks.Add(task);
	}

	[RelayCommand]
	public void RemoveTask(string task)
	{
		if (Tasks.Contains(task))
			Tasks.Remove(task);
	}
}