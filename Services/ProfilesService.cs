using System.Diagnostics;
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
    }
}