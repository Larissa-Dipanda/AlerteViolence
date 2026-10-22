using AlerteViolence.Views;

namespace AlerteViolence;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        //  Vérifie si l'utilisateur a déjà validé une connexion/inscription
        bool isLoggedIn = Preferences.Default.Get("IsLoggedIn", false);

        if (isLoggedIn)
        {
            // Si oui, on va directement à l'AppShell (qui affiche la TabBar et SosReportPage)
            return new Window(new AppShell());
        }
        else
        {
            // Sinon, on affiche l'écran de lancement classique
            return new Window(new LaunchingPage());
        }
    }
}