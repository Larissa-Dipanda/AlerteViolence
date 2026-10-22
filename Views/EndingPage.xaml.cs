namespace AlerteViolence.Views;

public partial class EndingPage : ContentPage
{
    public EndingPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Attend 1 seconde (1000 millisecondes)
        await Task.Delay(1000);

        // Ferme complètement l'application Android
        System.Environment.Exit(0);
    }
}