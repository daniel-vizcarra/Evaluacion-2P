using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace AppApuntes_DanielVizcarra.Views
{
    public partial class TextPageDV : ContentPage
    {
        public TextPageDV()
        {
            InitializeComponent();
        }

        private void OnAnalyzeClicked(object sender, EventArgs e)
        {
            string input = inputEntry.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                DisplayAlert("Error", "Ingrese una cadena valida.", "OK");
                return;
            }

            int totalCharacters = input.Length;
            int totalLetters = input.Count(char.IsLetter);
            int totalDigits = input.Count(char.IsDigit);
            int totalVowels = input.Count(c => "aeiouAEIOU".Contains(c));
            int totalUppercase = input.Count(char.IsUpper);
            int totalLowercase = input.Count(char.IsLower);

            resultGrid.Children.Clear();
            resultGrid.RowDefinitions.Clear();

            
            AddResultToGrid("   Letras:", totalLetters, "letters.png");
            AddResultToGrid("   Digitos:", totalDigits, "digits.png");
            AddResultToGrid("   Vocales:", totalVowels, "vowels.png");
            AddResultToGrid("   Mayusculas:", totalUppercase, "uppercase.png");
            AddResultToGrid("   Minusculas:", totalLowercase, "lowercase.png");
            AddResultToGrid("   Total:", totalCharacters, "total.png");
        }

        private void AddResultToGrid(string label, int value, string icon)
        {
            int rowIndex = resultGrid.RowDefinitions.Count;

            resultGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            var iconImage = new Image
            {
                Source = icon,
                HeightRequest = 24, 
                VerticalOptions = LayoutOptions.Center 
            };
            var labelControl = new Label
            {
                Text = $"{label} {value}",
                FontFamily = "Arial", 
                VerticalOptions = LayoutOptions.Center 
            };

            var stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center, 
                HorizontalOptions = LayoutOptions.Start 
            };

            stackLayout.Children.Add(iconImage);
            stackLayout.Children.Add(labelControl);

            resultGrid.Children.Add(stackLayout);

            Grid.SetRow(stackLayout, rowIndex);
            Grid.SetColumn(stackLayout, 0);
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            inputEntry.Text = string.Empty;
            resultGrid.Children.Clear();
            resultGrid.RowDefinitions.Clear();
        }
    }
}
