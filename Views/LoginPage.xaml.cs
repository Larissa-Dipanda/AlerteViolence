namespace AlerteViolence.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object? sender, EventArgs e)
    {
        // Sauvegarde l'état de connexion
        Preferences.Default.Set("IsLoggedIn", true);

        //await Shell.Current.DisplayAlert("Hi!", "Welcome Back", "OK");
        await Shell.Current.GoToAsync("//MainTabBar");
    }

    private async void OnSignUpTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }

    
    private async void OnForgotPasswordTapped(object? sender, TappedEventArgs e)
    {
        // Simulation réaliste d'un envoi d'email de réinitialisation
        await Shell.Current.DisplayAlertAsync(
            "Mot de passe oublié",
            "Un lien de réinitialisation a été envoyé à votre adresse e-mail. Veuillez consulter votre boîte de réception (Simulation).",
            "OK");
    }
}