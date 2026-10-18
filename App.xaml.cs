using AlerteViolence.Views;

namespace AlerteViolence;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // On démarre directement sur la page de lancement (sans Shell)
        MainPage = new LaunchingPage();
    }
}