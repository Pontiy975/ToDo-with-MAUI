using System.Collections.ObjectModel;

namespace ToDoApp.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public ObservableCollection<ToDoTask> Tasks { get; set; } = new();
    }
}
