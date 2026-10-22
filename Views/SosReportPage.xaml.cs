using AlerteViolence.ViewModels;

namespace AlerteViolence.Views;

public partial class SosReportPage : ContentPage
{
    public SosReportPage()
    {
        InitializeComponent();
        BindingContext = new SosReportViewModel();
    }

    // Méthode pour déclencher la page de fin
    private async void OnQuickExitClicked(object? sender, EventArgs e)
    {
        // Navigation vers la EndingPage. Le "//" réinitialise la pile de navigation
        await Shell.Current.GoToAsync("//EndingPage");
    }
}