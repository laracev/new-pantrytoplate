using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Text;

namespace Pantry_To_Plate.windows
{
    public partial class MahlzeitHinzufügenWindow : Window
    {
        List<string> foods = new List<string>();

        public MahlzeitHinzufügenWindow()
        {
            InitializeComponent();
            LoadCsv();
        }

        void LoadCsv()
        {
            string path = @"data/test_utf8.csv";

            if (!File.Exists(path))
            {
                MessageBox.Show("Datei nicht gefunden.");
                return;
            }

            
            var lines = File.ReadAllLines(path, Encoding.Latin1);

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(';');

                if (parts.Length > 0 &&
                    !string.IsNullOrWhiteSpace(parts[0]))
                {
                    foods.Add(parts[0]);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = TxtBoxLebensmittelHinzufügen.Text
                .ToLower()
                .Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                Btn_LebensMittelHinzufuegen.Content = "";
                return;
            }


            //Ki START CHATGPT
            //Promt: Ich habe eine List<string> foods und einen Input-String.
            //Schreibe mir eine Suchlogik, die zuerst prüft, ob ein Eintrag mit dem Input beginnt, dann ob ein einzelnes Wort im Eintrag mit dem
            //Input beginnt und zuletzt ob der Input irgendwo im String enthalten ist.
            //Es soll nur der erste Treffer verwendet werden.
            string match = null;

            
            match = foods.FirstOrDefault(f =>
                f.ToLower().StartsWith(input));

            
            if (match == null)
            {
                match = foods.FirstOrDefault(f =>
                    f.ToLower()
                     .Split(' ')
                     .Any(w => w.StartsWith(input)));
            }

           
            if (match == null)
            {
                match = foods.FirstOrDefault(f =>
                    f.ToLower().Contains(input));
            }

            if (match != null)
            {
                Btn_LebensMittelHinzufuegen.Content = match;
            }
            else
            {
                Btn_LebensMittelHinzufuegen.Content = "Kein Treffer";
            }
            //KI ENDE
        }

        private void Btn_LebensMittelHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            string food =
                Btn_LebensMittelHinzufuegen.Content.ToString();

            if (food != "Kein Treffer" &&
                !string.IsNullOrWhiteSpace(food))
            {
                
                if (!ListBoxLebensmittel.Items.Contains(food))
                {
                    ListBoxLebensmittel.Items.Add(food);
                }

                TxtBoxLebensmittelHinzufügen.Clear();

                Btn_LebensMittelHinzufuegen.Content = "";
            }
        }
    }
}