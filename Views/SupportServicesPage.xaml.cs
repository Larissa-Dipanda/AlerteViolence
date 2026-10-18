namespace AlerteViolence.Views;

public partial class SupportServicesPage : ContentPage
{
    public SupportServicesPage() { InitializeComponent(); }
    private async void OnServiceTapped(object sender, TappedEventArgs e)
    {
        string service = e.Parameter?.ToString() ?? "MINEDUB";
        await Shell.Current.GoToAsync($"{nameof(SupportDetailsPage)}?service={service}");
    }
}