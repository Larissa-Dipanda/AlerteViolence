using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;

namespace AlerteViolence.ViewModels;

public partial class AccueilViewModel : ObservableObject
{
    private readonly AlerteService _alerteService;

    //  Les propriétés sont générées automatiquement avec une MAJUSCULE (NatureMessage, Priorite, Description)
    [ObservableProperty]
    private string _natureMessage = string.Empty;

    [ObservableProperty]
    private string _priorite = string.Empty;

    [ObservableProperty]
    private string _description = string.Empty;

    public AccueilViewModel()
    {
        _alerteService = new AlerteService();
    }

    [RelayCommand]
    private async Task SoumettreRapportAsync()
    {
        //  Utilisez NatureMessage, Priorite, Description (pas _natureMessage, etc.)
        if (string.IsNullOrWhiteSpace(NatureMessage) || string.IsNullOrWhiteSpace(Priorite) || string.IsNullOrWhiteSpace(Description))
        {
            await Shell.Current.DisplayAlertAsync("Erreur", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        var rapport = new Rapport
        {
            Numero = "112", // Ou logique dynamique
            Type = NatureMessage,
            Statut = Priorite,
            Date = DateTime.Now,
            Description = Description
        };

        await _alerteService.SaveRapportAsync(rapport);

        await Shell.Current.DisplayAlertAsync("Succès", "Rapport envoyé et sauvegardé !", "OK");

        // Réinitialisation des champs avec les propriétés générées
        NatureMessage = string.Empty;
        Priorite = string.Empty;
        Description = string.Empty;
    }
}