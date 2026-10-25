namespace AlerteViolence;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // 1. On crée le Shell et la Fenêtre
        var shell = new AppShell();
        var window = new Window(shell);

        // 2. On attend que le Shell soit COMPLÈTEMENT chargé avant de naviguer
        shell.Loaded += (s, e) =>
        {
            bool isLoggedIn = Preferences.Default.Get("IsLoggedIn", false);

            if (isLoggedIn)
            {
                // Si connecté, on va directement à la barre d'onglets
                Shell.Current.GoToAsync("//MainTabBar");
            }
            else
            {
                // Sinon, on affiche l'écran de lancement
                Shell.Current.GoToAsync("//LaunchingPage");
            }
        };

        return window;
    }
}