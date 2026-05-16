using Pantry_To_Plate.mods;
using Pantry_To_Plate.windows;
using System.Windows;


namespace Pantry_To_Plate
{
    public partial class MainWindow : Window
    {
        //ki start: promt: wie mach ich am besten das es die werte immer aktuell sind?
        private void UpdateDailyValues()
        {
            var entries = DailyEntryService.LoadToday();

            double eatenCalories = entries.Sum(e => e.Calories);
            double eatenProtein = entries.Sum(e => e.Protein);
            double eatenCarbs = entries.Sum(e => e.Carbs);
            double eatenFat = entries.Sum(e => e.Fat);

            double remainingCalories = user.Kalorienziel - eatenCalories;

            KalorienzielText.Content =
                $"Kalorienziel: {user.Kalorienziel:F0} kcal\n" +
                $"Gegessen: {eatenCalories:F0} kcal\n" +
                $"Übrig: {remainingCalories:F0} kcal";
        }

        //KI ende
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