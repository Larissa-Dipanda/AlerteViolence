using AlerteViolence.ViewModels;

namespace AlerteViolence.Views;

public partial class ReportHistoryPage : ContentPage
{
    private readonly ReportHistoryViewModel _viewModel;

    public ReportHistoryPage()
    {
        InitializeComponent();
        _viewModel = new ReportHistoryViewModel();
        BindingContext = _viewModel;
    }

    //  Se déclenche à chaque fois que l'onglet "Logs" devient visible
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataAsync();
    }
    private async void OnQuickExitClicked(object? sender, EventArgs e)
    {
        // Navigation vers la EndingPage. Le "//" réinitialise la pile de navigation
        await Shell.Current.GoToAsync("//EndingPage");
    }
}