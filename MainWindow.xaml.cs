using Pantry_To_Plate.mods;
using Pantry_To_Plate.windows;
using System.Windows;
using System;
using System.Globalization;
using System.IO;
using System.Linq;


namespace Pantry_To_Plate
{
    public partial class MainWindow : Window
    {

        private double LoadBurnedCaloriesToday()
        {
            string path = @"data/FitnessEintraege.csv";

            if (!File.Exists(path))
            {
                return 0;
            }

            var lines = File.ReadAllLines(path).Skip(1);
            double burnedCalories = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(';');

                if (parts.Length >= 4 && DateTime.TryParse(parts[0], out DateTime date) && date.Date == DateTime.Today)
                {
                    if (double.TryParse(parts[3].Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out double kcal))
                    {
                        burnedCalories += kcal;
                    }
                }
            }

            return burnedCalories;
        }
        //ki start: promt: wie mach ich am besten das es die werte immer aktuell sind?
        private void UpdateDailyValues()
        {
            var entries = DailyEntryService.LoadToday();

            double eatenCalories = entries.Sum(e => e.Calories);
            double eatenProtein = entries.Sum(e => e.Protein);
            double eatenCarbs = entries.Sum(e => e.Carbs);
            double eatenFat = entries.Sum(e => e.Fat);


            double burnedCalories = LoadBurnedCaloriesToday();
            double netCalories = eatenCalories - burnedCalories;
            double remainingCalories = user.Kalorienziel - netCalories;

            KalorienzielText.Content =
                $"Kalorienziel: {user.Kalorienziel:F0} kcal\n" +
                $"Gegessen: {eatenCalories:F0} kcal\n" +
                $"Übrig: {remainingCalories:F0} kcal";

            //KI ende

            ProteineCounterLabel.Content = $"{eatenProtein:F0} g";
            CarbsCounterLabel.Content = $"{eatenCarbs:F0} g";
            FettCounterLabel.Content = $"{eatenFat:F0} g";

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EinstellungenWindow einstellungenWindow = new EinstellungenWindow(user);
            einstellungenWindow.Owner = this;
            einstellungenWindow.ShowDialog();

            try { KalorienzielText.Content = $"Kalorienziel: {user.Kalorienziel:F0} kcal"; }


            catch
            {
                KalorienzielText.Content = "Kalorienziel: 0 kcal";
            }
        }

        private userinfo user;

        public MainWindow()
        {
            InitializeComponent();
            user = UserDataService.Load();

            try { KalorienzielText.Content = $"Kalorienziel: {user.Kalorienziel:F0} kcal"; }
                
            
            catch
            {
                KalorienzielText.Content = "Kalorienziel: 0 kcal";
            }


            UpdateDailyValues();


        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MahlzeitHinzufügenWindow mahlzeitHinzufügenWindow = new MahlzeitHinzufügenWindow();
            mahlzeitHinzufügenWindow.Owner = this;
            mahlzeitHinzufügenWindow.ShowDialog();
            UpdateDailyValues();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            fitnessaktivitäthinzufügenwindow fitwin = new fitnessaktivitäthinzufügenwindow();
            fitwin.ShowDialog();
            UpdateDailyValues();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

       
    }
}