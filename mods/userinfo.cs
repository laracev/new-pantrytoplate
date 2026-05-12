using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Controls;

namespace Pantry_To_Plate.mods
{
    public class userinfo
    {
        public double Weight {  get; set; }
        public double Height {  get; set; }

        public double Age { get; set; }
        public int Genderchoice { get; set; }
        
        public double Kalorienziel {  get; set; }
        public int diätzielChoice { get; set; }

        public double palWert {  get; set; }



        public double KcalZielBerechnen(double Weight, double Height, int diätzielChoice, int Genderchoice, double Age)
        {
            double grundumsatz;

            if (Genderchoice == 1)
            {
                // Weiblich
                grundumsatz = 655 + (9.6 * Weight) + (1.8 * Height) - (4.6 * Age);
            }
            else if (Genderchoice == 2)
            {
                // Männlich
                grundumsatz = 66 + (13.7 * Weight) + (5 * Height) - (6.8 * Age);
            }
            else
            {
                return 0;
            }

            grundumsatz = grundumsatz * palWert;

            if (diätzielChoice == 1)
            {
                return grundumsatz + 500;
            }
            else if (diätzielChoice == 2)
            {
                return grundumsatz;
            }
            else if (diätzielChoice == 3)
            {
                return grundumsatz - 500;
            }
            else
            {
                return 0;
            }
        }






    }
    }

