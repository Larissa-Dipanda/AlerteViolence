namespace AlerteViolence.Views;

public partial class SupportDetailsPage : ContentPage
{
    public SupportDetailsPage()
    {
        InitializeComponent();
    }

    private async void OnRetourClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}