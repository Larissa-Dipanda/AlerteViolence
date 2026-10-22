using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;

namespace AlerteViolence.ViewModels;

public partial class RightsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Loi> _lois;

    public RightsViewModel()
    {
        var service = new DataService();
        Lois = new ObservableCollection<Loi>(service.GetLoisCamerounaises());
    }

    [RelayCommand]
    private async Task ShowDetailsAsync(object? parameter)
    {
        if (parameter is Loi loi)
        {
            await Shell.Current.DisplayAlertAsync(loi.Article,
                $"{loi.Titre}\n\n{loi.Description}\n\n⚖️ Peine : {loi.Peine}", "Fermer");
        }
    }
}