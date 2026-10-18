namespace AlerteViolence.Views;

public partial class EmergencyContactsPage : ContentPage
{
    public EmergencyContactsPage() { InitializeComponent(); }
    private async void OnContactTapped(object sender, TappedEventArgs e)
    {
        string numero = e.Parameter?.ToString() ?? "117";
        await Shell.Current.GoToAsync($"{nameof(EmergencyContactDetailsPage)}?numero={numero}");
    }
}