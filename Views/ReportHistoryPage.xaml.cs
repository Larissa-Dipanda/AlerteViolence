namespace AlerteViolence.Views;

public partial class ReportHistoryPage : ContentPage
{
    public ReportHistoryPage() { InitializeComponent(); }
    private async void OnReportTapped(object sender, TappedEventArgs e) => await Shell.Current.GoToAsync(nameof(ReportDetailsPage));
    private async void OnQuickDeleteClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlertAsync("Confirm", "Are you sure you want to delete all history?", "Yes", "No");
        if (answer) await DisplayAlertAsync("Deleted", "History cleared.", "OK");
    }
}