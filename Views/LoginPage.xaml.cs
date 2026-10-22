namespace AlerteViolence.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        // Simulation de connexion réussie -> Affichage du Pop-up "Hi! Welcome Back"
        //await DisplayAlert("Hi!", "Welcome Back", "OK");

        // Navigation vers la barre d'onglets principale (SosReportPage est le premier onglet)
        // Le "//" permet de réinitialiser la pile de navigation
        await Shell.Current.GoToAsync("//MainTabBar");
    }

    private async void OnSignUpTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }

    private void OnForgotPasswordTapped(object sender, TappedEventArgs e)
    {
        DisplayAlertAsync("Info", "Fonctionnalité de récupération à implémenter.", "OK");
    }
}