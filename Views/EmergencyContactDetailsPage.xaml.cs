namespace AlerteViolence.Views;

public partial class EmergencyContactDetailsPage : ContentPage
{
    public EmergencyContactDetailsPage() { InitializeComponent(); }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        var uri = Shell.Current?.CurrentState?.Location;
        var query = uri?.Query;
        if (string.IsNullOrEmpty(query))
            return;

        var pairs = query.TrimStart('?').Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var pair in pairs)
        {
            var kv = pair.Split(new[] { '=' }, 2);
            var key = Uri.UnescapeDataString(kv[0]);
            var value = kv.Length > 1 ? Uri.UnescapeDataString(kv[1]) : string.Empty;

            if (key == "numero")
            {
                LblContact.Text = "Contact: " + value;
                break;
            }
        }
    }
    private async void OnBackClicked(object sender, EventArgs e) => await Shell.Current.GoToAsync("..");
}