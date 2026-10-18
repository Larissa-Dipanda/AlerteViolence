using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Devices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

#if ANDROID
// using static Android.Util.EventLog; // supprimé car non utilisé
#endif

namespace AlerteViolence.ViewModels;

public partial class ReportDescriptionViewModel : ObservableObject
{
    [ObservableProperty]
    private string dateRapport = DateTime.Now.ToString("dd/MM/yyyy");

    [ObservableProperty]
    private string statutSelectionne = "Victime";

    [ObservableProperty]
    private string description = string.Empty;

    public List<string> Statuts { get; } = new() { "Victime", "Témoin" };

    [RelayCommand]
    private async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(Description))
        {
            await Shell.Current.DisplayAlertAsync("Attention", "Veuillez remplir la description.", "OK");
            return;
        }

        // Simulation de sauvegarde
        await Task.Delay(500);

        // Message de confirmation (correspond à l'écran "ADDED" de ta maquette)
        await Shell.Current.DisplayAlertAsync("Succès", "ADDED\nVotre signalement a été enregistré de manière sécurisée.", "OK");

        // Retour à l'historique ou à l'accueil
        await Shell.Current.GoToAsync("..");
    }
}