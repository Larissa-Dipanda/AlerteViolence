namespace AlerteViolence.Views;

public partial class SosReportPage : ContentPage
{
    public SosReportPage()
    {
        InitializeComponent();
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EntryType.Text) || PickerStatus.SelectedItem == null)
        {
            await DisplayAlertAsync("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        // Navigation vers la page de description détaillée (Report-Description)
        // On utilise "///" pour empiler la page par-dessus la TabBar
        await Shell.Current.GoToAsync(nameof(ReportDescriptionPage));
    }
}