using System;
using System.Collections.Generic;
using System.Text;

namespace Pantry_To_Plate.mods
{
    public class fitnessactivity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Met {  get; set; }


        public double CalculateCalories(double weightKg, double durationMinutes)
        {
            return Met * weightKg * (durationMinutes / 60.0);
        }
    }
}
