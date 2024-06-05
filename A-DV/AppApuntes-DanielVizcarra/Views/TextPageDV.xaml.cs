namespace AppApuntes_DanielVizcarra.Views;

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

        resultStack.Children.Clear();
        resultStack.Children.Add(new Label { Text = $"Total Characters: {totalCharacters}" });
        resultStack.Children.Add(new Label { Text = $"Total Letters: {totalLetters}" });
        resultStack.Children.Add(new Label { Text = $"Total Digits: {totalDigits}" });
        resultStack.Children.Add(new Label { Text = $"Total Vowels: {totalVowels}" });
        resultStack.Children.Add(new Label { Text = $"Total Uppercase: {totalUppercase}" });
        resultStack.Children.Add(new Label { Text = $"Total Lowercase: {totalLowercase}" });
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        inputEntry.Text = string.Empty;
        resultStack.Children.Clear();
    }
}
