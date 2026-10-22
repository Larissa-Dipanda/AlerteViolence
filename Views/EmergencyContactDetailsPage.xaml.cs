namespace AlerteViolence.Views;

public partial class EmergencyContactDetailsPage : ContentPage
{
    public EmergencyContactDetailsPage()
    {
        InitializeComponent();
    }

    private async void OnRetourClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}