using AlerteViolence.Views;

namespace AlerteViolence;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Uniquement l'enregistrement des routes ici. 
        // Pas de Shell.Current.GoToAsync dans le constructeur !
        Routing.RegisterRoute(nameof(LaunchingPage), typeof(LaunchingPage));
        Routing.RegisterRoute(nameof(EntryPage), typeof(EntryPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        Routing.RegisterRoute(nameof(SosReportPage), typeof(SosReportPage));
        Routing.RegisterRoute(nameof(EmergencyContactsPage), typeof(EmergencyContactsPage));
        Routing.RegisterRoute(nameof(EmergencyContactDetailsPage), typeof(EmergencyContactDetailsPage));
        Routing.RegisterRoute(nameof(SupportServicesPage), typeof(SupportServicesPage));
        Routing.RegisterRoute(nameof(SupportDetailsPage), typeof(SupportDetailsPage));
        Routing.RegisterRoute(nameof(ReportDescriptionPage), typeof(ReportDescriptionPage));
        Routing.RegisterRoute(nameof(ReportDetailsPage), typeof(ReportDetailsPage));
        Routing.RegisterRoute(nameof(RightsPage), typeof(RightsPage));
        Routing.RegisterRoute(nameof(ReportHistoryPage), typeof(ReportHistoryPage));
        Routing.RegisterRoute(nameof(EndingPage), typeof(EndingPage));
        Routing.RegisterRoute(nameof(CalculatricePage), typeof(CalculatricePage));
    }
}