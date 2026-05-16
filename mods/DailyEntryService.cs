using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Pantry_To_Plate.mods
{
    public static class DailyEntryService
    {
        private static string GetPath()
        {
            Directory.CreateDirectory("data");
            return $@"data\gegessen_{DateTime.Today:yyyy-MM-dd}.csv";
        }

        public static void Add(DailyEntry entry)
        {
            string path = GetPath();
            bool fileExists = File.Exists(path);

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                if (!fileExists)
                {
                    writer.WriteLine("FoodName;AmountGram;Calories;Protein;Carbs;Fat");
                }

                writer.WriteLine(
                    entry.FoodName + ";" +
                    entry.AmountGram.ToString(CultureInfo.InvariantCulture) + ";" +
                    entry.Calories.ToString(CultureInfo.InvariantCulture) + ";" +
                    entry.Protein.ToString(CultureInfo.InvariantCulture) + ";" +
                    entry.Carbs.ToString(CultureInfo.InvariantCulture) + ";" +
                    entry.Fat.ToString(CultureInfo.InvariantCulture)
                );
            }
        }

        public static List<DailyEntry> LoadToday()
        {
            List<DailyEntry> entries = new List<DailyEntry>();
            string path = GetPath();

            if (!File.Exists(path))
            {
                return entries;
            }

            var lines = File.ReadAllLines(path).Skip(1);

            foreach (string line in lines)
            {
                var parts = line.Split(';');

                if (parts.Length >= 6)
                {
                    entries.Add(new DailyEntry
                    {
                        FoodName = parts[0],
                        AmountGram = double.Parse(parts[1], CultureInfo.InvariantCulture),
                        Calories = double.Parse(parts[2], CultureInfo.InvariantCulture),
                        Protein = double.Parse(parts[3], CultureInfo.InvariantCulture),
                        Carbs = double.Parse(parts[4], CultureInfo.InvariantCulture),
                        Fat = double.Parse(parts[5], CultureInfo.InvariantCulture)
                    });
                }
            }

            return entries;
        }
    }
}