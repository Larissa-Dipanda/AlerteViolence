namespace AlerteViolence.Views;

public partial class ReportDescriptionPage : ContentPage
{
    public ReportDescriptionPage()
    {
        InitializeComponent();
    }

    private async void OnSauvegarderClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Succès", "Rapport ajouté avec succès !", "OK");
        await Shell.Current.GoToAsync("..");
    }
}