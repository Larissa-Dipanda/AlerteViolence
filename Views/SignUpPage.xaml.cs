namespace AlerteViolence.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object sender, EventArgs e)
    {
        await DisplayAlertAsync("Succès", "Compte créé avec succès !", "OK");
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    private async void OnLoginTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}