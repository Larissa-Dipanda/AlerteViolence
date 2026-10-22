using AlerteViolence.Models;

namespace AlerteViolence.Views;

public partial class ReportDetailsPage : ContentPage
{
    public ReportDetailsPage(Rapport rapport)
    {
        InitializeComponent();

        // On peut  maintenant lier les données du rapport aux Labels de la page
        // Exemple : DateLabel.Text = rapport.Date.ToString("dd/MM/yyyy");
        BindingContext = rapport;
    }
}