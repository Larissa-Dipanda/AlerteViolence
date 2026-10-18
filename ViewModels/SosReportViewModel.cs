using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AlerteViolence.ViewModels;

public partial class SosReportViewModel : ObservableObject
{
    // Les propriétés générées seront : TypeRapport et StatutSelectionne
    [ObservableProperty]
    private string typeRapport = string.Empty;

    [ObservableProperty]
    private string statutSelectionne = string.Empty;

    [RelayCommand]
    private async Task SubmitReportAsync()
    {
        
        if (string.IsNullOrWhiteSpace(TypeRapport) || string.IsNullOrWhiteSpace(StatutSelectionne))
        {
            await Shell.Current.DisplayAlertAsync("Attention", "Veuillez remplir le type de rapport et choisir un statut.", "OK");
            return;
        }

        // Simulation d'envoi
        await Shell.Current.DisplayAlertAsync("Succès", "Rapport soumis avec succès.", "OK");

        // Réinitialisation en utilisant les propriétés générées
        TypeRapport = string.Empty;
        StatutSelectionne = string.Empty;

        // Navigation vers la page de description (prochaine étape)
        // await Shell.Current.GoToAsync(nameof(ReportDescriptionPage));
    }
}