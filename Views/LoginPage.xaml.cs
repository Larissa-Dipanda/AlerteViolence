namespace AlerteViolence.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            await Task.Delay(200);
            await DisplayAlertAsync("Hi!", "Welcome Back", "OK");

            // Navigation vers l'onglet SOS de la TabBar
            await Shell.Current.GoToAsync("///MainTabBar/SosReportPage");
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Erreur", ex.Message, "OK");
        }
    }

    private async void OnSignUpTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SignUpPage));
    }

    private async void OnForgotPasswordTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlertAsync("Info", "Fonctionnalité de récupération de mot de passe à implémenter.", "OK");
    }
}