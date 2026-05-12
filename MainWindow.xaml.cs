using Pantry_To_Plate.mods;
using Pantry_To_Plate.windows;
using System.Windows;

namespace Pantry_To_Plate
{
    public partial class MainWindow : Window
    {
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MahlzeitHinzufügenWindow mahlzeitHinzufügenWindow = new MahlzeitHinzufügenWindow();
            mahlzeitHinzufügenWindow.Owner = this;
            mahlzeitHinzufügenWindow.ShowDialog();
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