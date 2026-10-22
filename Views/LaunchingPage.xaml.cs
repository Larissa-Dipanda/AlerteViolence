//using static Android.Icu.Text.UnicodeSet;

namespace AlerteViolence.Views;

public partial class LaunchingPage : ContentPage
{
    public LaunchingPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Attend 1 seconde pour simuler le chargement
        await Task.Delay(1000);

        // Redirige vers l'écran EntryPage
        await Shell.Current.GoToAsync(nameof(EntryPage));
    }
}