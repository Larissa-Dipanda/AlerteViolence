using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;

namespace AlerteViolence.ViewModels;

public partial class LoisViewModel : ObservableObject
{
    private readonly DataService _dataService;
    private List<Loi> _allLois = new();

    [ObservableProperty]
    private ObservableCollection<Loi> lois = new();

    [ObservableProperty]
    private string searchText = string.Empty;

    [ObservableProperty]
    private string selectedCategorie = "Toutes";

    [ObservableProperty]
    private bool isLoading = true;

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
            _allLois = await _dataService.GetLoisAsync();
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

    /// <summary>
    /// Applique les filtres (recherche + catégorie) sur la liste des lois
    /// </summary>
    [RelayCommand]
    private void FilterLois()
    {
        var filtered = _allLois.AsEnumerable();

        // Filtre par catégorie
        if (SelectedCategorie != "Toutes")
        {
            filtered = filtered.Where(l => l.Categorie == SelectedCategorie);
        }

        // Filtre par recherche (titre, article, description)
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

    /// <summary>
    /// Déclenché automatiquement quand SearchText change
    /// </summary>
    partial void OnSearchTextChanged(string value)
    {
        FilterLois();
    }

    /// <summary>
    /// Déclenché automatiquement quand SelectedCategorie change
    /// </summary>
    partial void OnSelectedCategorieChanged(string value)
    {
        FilterLois();
    }

    /// <summary>
    /// Ouvre le lien web de la loi dans le navigateur
    /// </summary>
    [RelayCommand]
    private async Task OpenLienWeb(Loi loi)
    {
        if (string.IsNullOrWhiteSpace(loi.LienWeb))
        {
            await Shell.Current.DisplayAlertAsync("Information", "Aucun lien disponible pour cet article.", "OK");
            return;
        }

        // Vérifie la connexion internet
        if (Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlertAsync("Pas de connexion", "Vous devez être connecté à Internet pour accéder à cette page.", "OK");
            return;
        }

        try
        {
            await Browser.Default.OpenAsync(loi.LienWeb, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Erreur", $"Impossible d'ouvrir le lien : {ex.Message}", "OK");
        }
    }
}