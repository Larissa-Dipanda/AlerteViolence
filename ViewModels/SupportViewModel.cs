using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;
using Microsoft.Maui.ApplicationModel.Communication; //INDISPENSABLE pour le téléphone et le navigateur

namespace AlerteViolence.ViewModels;

public partial class SupportViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Structure> _structures = new();

    public SupportViewModel()
    {
        var service = new DataService();
        Structures = new ObservableCollection<Structure>(service.GetStructuresCameroun());
    }

    [RelayCommand]
    private async Task ShowDetailsAsync(object? parameter)
    {
        if (parameter is Structure structure)
        {
            // 1. On affiche les détails et on propose 2 actions (au lieu d'un simple DisplayAlert)
            string action = await Shell.Current.DisplayActionSheet(
                $"{structure.Nom}\n\n📍 {structure.Adresse}\n\n{structure.Description}",
                "Annuler", // Bouton pour fermer
                null,
                "📞 Appeler ce numéro", // Bouton d'action 1
                "🌐 Ouvrir le site web" // Bouton d'action 2
            );

            // 2. On exécute l'action choisie
            if (action == "📞 Appeler ce numéro" && !string.IsNullOrWhiteSpace(structure.Telephone))
            {
                try
                {
                    //  On nettoie le numéro (on enlève les espaces et tirets) 
                    // pour éviter que le composeur Android ne bloque.
                    string numeroPropre = structure.Telephone.Replace(" ", "").Replace("-", "");
                    PhoneDialer.Default.Open(numeroPropre);
                }
                catch (Exception)
                {
                    await Shell.Current.DisplayAlert("Erreur", "Impossible d'appeler. Cette fonction ne marche que sur un vrai téléphone.", "OK");
                }
            }
            else if (action == "🌐 Ouvrir le site web" && !string.IsNullOrWhiteSpace(structure.LienWeb))
            {
                try
                {
                    await Browser.Default.OpenAsync(structure.LienWeb, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception)
                {
                    await Shell.Current.DisplayAlert("Erreur", "Impossible d'ouvrir le lien.", "OK");
                }
            }
        }
    }
}