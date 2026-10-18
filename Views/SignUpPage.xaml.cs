namespace AlerteViolence.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        // Après inscription, on redirige vers l'accueil
        await Shell.Current.GoToAsync("//MainTabBar/SosReportPage");
    }

    private async void OnLoginTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}