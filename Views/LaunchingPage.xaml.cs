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

        // 1. Attendre 1 secondes (1000 millisecondes)
        await Task.Delay(1000);

        // 2. Remplacer la page actuelle par le Shell principal de l'application
        // Cela évite tous les problèmes de routing du Shell au démarrage
        Application.Current.MainPage = new AppShell();
    }
}