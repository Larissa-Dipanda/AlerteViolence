namespace AlerteViolence.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage()
    {
        InitializeComponent();
    }

    private async void OnSignUpClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EntryNom.Text))
        {
            await Shell.Current.DisplayAlertAsync("Erreur", "Veuillez entrer votre nom.", "OK");
            return;
        }

        // SAUVEGARDE DU NOM dans la mémoire du téléphone
        Preferences.Default.Set("NomUtilisateur", EntryNom.Text);
        Preferences.Default.Set("EmailUtilisateur", EntryEmail.Text);
        Preferences.Default.Set("IsLoggedIn", true);

        await Shell.Current.DisplayAlertAsync("Succès", "Compte créé avec succès !", "OK");
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    private async void OnLoginTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}