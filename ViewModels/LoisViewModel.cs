using System.Collections.ObjectModel;
using System.Linq; //  INDISPENSABLE pour les méthodes .Where() et .AsEnumerable()
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Devices;

namespace AlerteViolence.ViewModels;

public partial class LoisViewModel : ObservableObject
{
    private readonly DataService _dataService;
    private List<Loi> _allLois = new();

    [ObservableProperty]
    private ObservableCollection<Loi> _lois = new();

    [ObservableProperty]
    private string _searchText = string.Empty;

    [ObservableProperty]
    private string _selectedCategorie = "Toutes";

    [ObservableProperty]
    private bool _isLoading = true;

    public List<string> Categories { get; } = new()
    {
        "Toutes",
        "Violences Physiques",
        "Violences Sexuelles",
        "Menaces et Harcèlement",
        "Protection de l'Enfance",
        "Mariages Forcés et Enlèvement",
        "Non-Assistance et Dignité"
    };

    public LoisViewModel()
    {
        _dataService = new DataService();
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            IsLoading = true;
            _allLois = _dataService.GetLoisCamerounaises();
            FilterLois();
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Erreur", $"Impossible de charger les données : {ex.Message}", "OK");
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    private void FilterLois()
    {
        var filtered = _allLois.AsEnumerable();

        if (SelectedCategorie != "Toutes")
        {
            filtered = filtered.Where(l => l.Categorie == SelectedCategorie);
        }

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var searchLower = SearchText.ToLower();
            filtered = filtered.Where(l =>
                l.Titre.ToLower().Contains(searchLower) ||
                l.Article.ToLower().Contains(searchLower) ||
                l.Description.ToLower().Contains(searchLower));
        }

        Lois.Clear();
        foreach (var loi in filtered)
        {
            Lois.Add(loi);
        }
    }

    partial void OnSearchTextChanged(string value) => FilterLois();
    partial void OnSelectedCategorieChanged(string value) => FilterLois();

    [RelayCommand]
    private async Task OpenLienWeb(Loi loi)
    {
        if (string.IsNullOrWhiteSpace(loi.LienWeb))
        {
            await Shell.Current.DisplayAlertAsync("Information", "Aucun lien disponible pour cet article.", "OK");
            return;
        }

        if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlertAsync("Pas de connexion", "Vous devez être connecté à Internet pour accéder à cette page.", "OK");
            return;
        }

        try
        {
            await Browser.Default.OpenAsync(loi.LienWeb, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlertAsync("Erreur", "Impossible d'ouvrir le lien.", "OK");
        }
    }
}