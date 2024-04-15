//using System.Collections.ObjectModel;
//using System.Text.Json;
//using ToDoApp.ViewModels;

//namespace ToDoApp
//{
//    internal static class JsonParser
//    {
//        private static string _filePath = "./Data/profiles.json";

//        public static void Save(ObservableCollection<Profile> profiles)
//        {
//            using StreamWriter writer = new StreamWriter(_filePath);
//            writer.Write(JsonSerializer.Serialize(profiles, new JsonSerializerOptions() { WriteIndented = true }));
//        }

//        public static ObservableCollection<Profile> Load()
//        {
//            if (File.Exists(_filePath))
//            {
//                try
//                {
//                    using (StreamReader reader = new StreamReader(_filePath))
//                    {
//                        string json = reader.ReadToEnd();
//                        var data = JsonSerializer.Deserialize<ObservableCollection<Profile>>(json);

//                        if (data != null)
//                            return data;
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Помилка десеріалізації: {ex.Message}");
//                }
//            }

//            return new ObservableCollection<Profile>();
//        }
//    }
//}
