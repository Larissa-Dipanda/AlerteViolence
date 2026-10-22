using Microsoft.UI.Xaml;

// ️ TRÈS IMPORTANT : Le namespace doit finir par ".WinUI" pour ne pas entrer en conflit avec l'App mobile
namespace AlerteViolence.WinUI;

public partial class App : MauiWinUIApplication
{
    public App()
    {
        this.InitializeComponent();
    }

    //  Cette méthode est OBLIGATOIRE pour Windows
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}