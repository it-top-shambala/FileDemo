using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace FileDemo.Serialization
{
    internal static class Program
    {
        private static void Main()
        {
            var users = new List<User>()
            {
                new User
                {
                    FirstName = "Андрей", 
                    LastName = "Старинин"
                },
                new User{ FirstName = "Andrey", LastName = "Starinin" },
                new User{ FirstName = "Andrey", LastName = "Starinin" }
            };
            var path = "users.json";

            using (var file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(file, users);
            }

            /*
            using (var file = new StreamWriter("users2.json"))
            {
                var json = JsonSerializer.Serialize(users);
                file.WriteLine(json);
            }
            */
            
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var users2 = JsonSerializer.Deserialize<List<User>>(file);

                foreach (var user in users2)
                {
                    Console.WriteLine($"{user.LastName} {user.FirstName}");
                }
            }

            var dict = new Dictionary<string, string>()
            {
                {"first", "первый"},
                {"second", "второй"},
            };
            
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            using (var file = new FileStream("dict.json", FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(file, dict, options);
            }
        }
    }
}