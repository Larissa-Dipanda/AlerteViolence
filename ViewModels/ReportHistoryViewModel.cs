using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;
using AlerteViolence.Views;

namespace AlerteViolence.ViewModels;

public partial class ReportHistoryViewModel : ObservableObject
{
    private readonly AlerteService _alerteService;

    // Initialisation directe de la collection pour éviter les nulls
    [ObservableProperty]
    private ObservableCollection<Rapport> _rapports = new();

    public ReportHistoryViewModel()
    {
        _alerteService = new AlerteService();
    }

    /// <summary>
    /// Méthode appelée par la Vue (ReportHistoryPage.xaml.cs) dans OnAppearing()
    /// </summary>
    public async Task LoadDataAsync()
    {
        var list = await _alerteService.GetRapportsAsync();
        Rapports.Clear();

        foreach (var r in list)
        {
            Rapports.Add(r);
        }
    }

    [RelayCommand]
    private async Task QuickDeleteAsync()
    {
        bool confirm = await Shell.Current.DisplayAlertAsync(
            "Suppression rapide",
            "Voulez-vous vraiment effacer tout l'historique ?",
            "Oui",
            "Non");

        if (confirm)
        {
            await _alerteService.DeleteAllRapportsAsync();
            Rapports.Clear(); // On vide la collection immédiatement pour une mise à jour UI instantanée
        }
    }

    [RelayCommand]
    private async Task ShowDetailsAsync(object? parameter)
    {
        if (parameter is Rapport rapport)
        {
            // Navigation vers la page de détails en passant l'objet en paramètre
            var navigationParameter = new Dictionary<string, object>
            {
                { "Rapport", rapport }
            };

            await Shell.Current.GoToAsync(nameof(ReportDetailsPage), navigationParameter);
        }
    }
}