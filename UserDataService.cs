using Pantry_To_Plate.mods;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace Pantry_To_Plate
{
    public static class UserDataService
    {
        private static string filePath = "userinfo.json";

        public static void Save(userinfo user)
        {
            string json = JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        public static userinfo Load()
        {
            if (!File.Exists(filePath))
            {
                return new userinfo();
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<userinfo>(json) ?? new userinfo(); 
        }
    }
}
