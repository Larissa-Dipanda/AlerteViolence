using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;
using Microsoft.Maui.ApplicationModel;

namespace AlerteViolence.ViewModels;

public partial class RightsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Loi> _lois = new();

    public RightsViewModel()
    {
        var service = new DataService();
        // ✅ CORRECTION : Appel de la bonne méthode GetLoisCamerounaises()
        Lois = new ObservableCollection<Loi>(service.GetLoisCamerounaises());
    }

    [RelayCommand]
    private async Task ShowDetailsAsync(object? parameter)
    {
        if (parameter is Loi loi)
        {
            //  Utilisation de DisplayActionSheetAsync
            string action = await Shell.Current.DisplayActionSheetAsync(
                $"⚖️ {loi.Article}\n\n{loi.Titre}\n\n{loi.Description}\n\nPeine : {loi.Peine}",
                "Fermer",
                null,
                "🌐 Ouvrir le lien officiel"
            );

            if (action == "🌐 Ouvrir le lien officiel")
            {
                try
                {
                    await Browser.Default.OpenAsync(loi.LienWeb, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception)
                {
                    await Shell.Current.DisplayAlertAsync("Erreur", "Impossible d'ouvrir le navigateur.", "OK");
                }
            }
        }
    }
}