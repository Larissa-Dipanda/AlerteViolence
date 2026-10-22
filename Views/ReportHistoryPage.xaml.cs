using System.Collections.ObjectModel;

namespace AlerteViolence.Views;

public class Rapport
{
    public string Numero { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Statut { get; set; } = string.Empty;
}

public partial class ReportHistoryPage : ContentPage
{
    public ObservableCollection<Rapport> Rapports { get; set; } = new();

    public ReportHistoryPage()
    {
        InitializeComponent();
        BindingContext = this;
        ChargerRapports();
    }

    private void ChargerRapports()
    {
        Rapports.Add(new Rapport { Numero = "112", Type = "Menaces", Statut = "Victime" });
        Rapports.Add(new Rapport { Numero = "117", Type = "Violence conjugale", Statut = "Victime" });
        Rapports.Add(new Rapport { Numero = "118", Type = "Maltraitance", Statut = "Témoin" });
    }

    private async void OnSuppressionRapideClicked(object sender, EventArgs e)
    {
        bool confirmer = await DisplayAlertAsync("Suppression rapide", "Voulez-vous vraiment supprimer tout l'historique ?", "Oui", "Non");
        if (confirmer)
        {
            Rapports.Clear();
        }
    }
}