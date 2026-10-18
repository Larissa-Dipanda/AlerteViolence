using AlerteViolence.Views;

namespace AlerteViolence;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // 1. Enregistrement des routes globales pour l'authentification
        //Routing.RegisterRoute(nameof(LaunchingPage), typeof(LaunchingPage));
        Routing.RegisterRoute(nameof(EntryPage), typeof(EntryPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));

        // 2. Enregistrement des routes globales pour les pages de détails et secondaires
        Routing.RegisterRoute(nameof(EmergencyContactDetailsPage), typeof(EmergencyContactDetailsPage));
        Routing.RegisterRoute(nameof(SupportDetailsPage), typeof(SupportDetailsPage));
        Routing.RegisterRoute(nameof(ReportDescriptionPage), typeof(ReportDescriptionPage));
        Routing.RegisterRoute(nameof(ReportDetailsPage), typeof(ReportDetailsPage));
        Routing.RegisterRoute(nameof(EndingPage), typeof(EndingPage));
    }
}