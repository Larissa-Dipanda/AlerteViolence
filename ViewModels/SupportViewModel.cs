using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;

namespace AlerteViolence.ViewModels;

public partial class SupportViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Structure> _structures;

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
            await Shell.Current.DisplayAlertAsync(structure.Nom,
                $"Lieu: {structure.Adresse}\nTél: {structure.Telephone}\n\n{structure.Description}", "Fermer");
        }
    }
}