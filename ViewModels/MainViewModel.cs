using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ToDoApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty] private ObservableCollection<string> _items;

	[ObservableProperty] private string _text;

	public MainViewModel()
	{
		_items = new ObservableCollection<string>();
		_text = string.Empty;
	}

	[RelayCommand]
	public void AddItem()
	{
		if (string.IsNullOrEmpty(Text))
			return;

		Items.Add(Text);

		Text = string.Empty;
	}

	[RelayCommand]
	public void RemoveItem(string item)
	{
		if (Items.Contains(item))
			Items.Remove(item);
	}
}