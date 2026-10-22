namespace AlerteViolence.Views;

public partial class ReportDetailsPage : ContentPage
{
    public ReportDetailsPage()
    {
        InitializeComponent();
    }

    private async void OnRetourClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}