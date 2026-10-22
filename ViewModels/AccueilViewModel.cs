using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Devices;
using AlerteViolence.Views;

namespace AlerteViolence.ViewModels;

public partial class AccueilViewModel : ObservableObject
{
    [ObservableProperty]
    private string natureMessage;

    [ObservableProperty]
    private string priorite;

    [ObservableProperty]
    private string description;

    public bool IsEnvoiEnCours { get; set; }

    public List<string> NaturesMessage { get; } = new()
    {
        "Situation personnelle",
        "Témoignage",
        "Demande d'information",
        "Autre"
    };

    public List<string> Priorites { get; } = new()
    {
        "Normale",
        "Importante",
        "Urgente"
    };

    public AccueilViewModel()
    {
        // Initialisation des valeurs par défaut
        natureMessage = string.Empty;
        priorite = string.Empty;
        description = string.Empty;
        IsEnvoiEnCours = false;
    }

    [RelayCommand]
    private async Task EnvoyerAlerteAsync()
    {
        if (string.IsNullOrWhiteSpace(natureMessage) ||
            string.IsNullOrWhiteSpace(priorite) ||
            string.IsNullOrWhiteSpace(description))
        {
            await Shell.Current.DisplayAlertAsync("Information requise", "Veuillez remplir tous les champs.", "OK");
            return;
        }

        IsEnvoiEnCours = true;

        try
        {
            await Task.Delay(500);

            if (DeviceInfo.Platform != DevicePlatform.WinUI)
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(200));
            }

            await Shell.Current.DisplayAlertAsync("Envoyé", "Votre message a été transmis.", "OK");

            natureMessage = string.Empty;
            priorite = string.Empty;
            description = string.Empty;
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlertAsync("Erreur", ex.Message, "OK");
        }
        finally
        {
            IsEnvoiEnCours = false;
        }
    }

    [RelayCommand]
    private async Task EffacementRapideAsync()
    {
        if (DeviceInfo.Platform != DevicePlatform.WinUI)
        {
            Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(100));
        }

        natureMessage = string.Empty;
        priorite = string.Empty;
        description = string.Empty;

        await Shell.Current.GoToAsync(nameof(CalculatricePage));
    }

    [RelayCommand]
    private async Task NaviguerVersLoisAsync()
    {
        await Shell.Current.GoToAsync(nameof(LoisPage));
    }
}