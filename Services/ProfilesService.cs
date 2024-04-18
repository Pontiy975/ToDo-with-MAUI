using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class ProfilesService
    {
        private static string FILE_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "profiles.json");

        private List<Profile> _profiles = new();

        public List<Profile> GetProfiles()
        {
            if (File.Exists(FILE_PATH))
            {
                try
                {
                    using FileStream fstream = File.OpenRead(FILE_PATH);
                    var profiles = JsonSerializer.Deserialize<List<Profile>>(fstream);

                    if (profiles != null)
                        _profiles = profiles;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"ATTENTION!!! {ex.Message}");
                }
            }
            else
            {
                Directory.CreateDirectory($"{AppDomain.CurrentDomain.BaseDirectory}/Data");
                File.Create(FILE_PATH);
            }

            return _profiles;
        }

        public void SaveProfiles(ObservableCollection<Profile> profiles)
        {
            if (File.Exists(FILE_PATH))
            {
                string json = JsonSerializer.Serialize(profiles);
                byte[] jsonBytes = Encoding.UTF8.GetBytes(json);

                using FileStream fstream = File.OpenWrite(FILE_PATH);
                fstream.Write(jsonBytes, 0, jsonBytes.Length);
            }
        }

        public void ClearProfiles()
        {
            if (File.Exists(FILE_PATH))
            {
                using FileStream fstream = File.OpenWrite(FILE_PATH);
                fstream.SetLength(0);
            }
        }
    }
}