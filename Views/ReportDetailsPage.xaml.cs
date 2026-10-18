namespace AlerteViolence.Views;

public partial class ReportDetailsPage : ContentPage
{
    public ReportDetailsPage()
    {
        // Initialise l'interface en C# si aucun XAML n'est présent
        Content = new StackLayout
        {
            Padding = 20,
            Children =
            {
                new Label { Text = "Détails du signalement", FontSize = 18 },
                // ajouter d'autres contrôles nécessaires ici
            }
        };
    }

    private async void OnBackClicked(object s, EventArgs e) => await Shell.Current.GoToAsync("..");
}