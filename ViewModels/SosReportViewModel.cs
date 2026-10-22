using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;

namespace AlerteViolence.ViewModels;

public partial class SosReportViewModel : ObservableObject
{
    private readonly AlerteService _alerteService;

    // Propriété pour le nom de l'utilisateur
    [ObservableProperty]
    private string _userName = "Utilisateur";

    [ObservableProperty]
    private string _typeRapport = string.Empty;

    [ObservableProperty]
    private string _statut = string.Empty;

    public SosReportViewModel()
    {
        _alerteService = new AlerteService();

        // LECTURE DU NOM sauvegardé lors de l'inscription
        UserName = Preferences.Default.Get("NomUtilisateur", "Utilisateur");
    }

    [RelayCommand]
    private async Task SubmitReportAsync()
    {
        if (string.IsNullOrWhiteSpace(TypeRapport) || string.IsNullOrWhiteSpace(Statut))
        {
            await Shell.Current.DisplayAlertAsync("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        var rapport = new Rapport
        {
            Numero = "112",
            Type = TypeRapport,
            Statut = Statut,
            Date = DateTime.Now,
            Description = "Rapport rapide soumis via l'application."
        };

        await _alerteService.SaveRapportAsync(rapport);

        await Shell.Current.DisplayAlertAsync("Succès", "Rapport envoyé et sauvegardé !", "OK");

        // Réinitialiser les champs après l'envoi
        TypeRapport = string.Empty;
        Statut = string.Empty;
    }
}