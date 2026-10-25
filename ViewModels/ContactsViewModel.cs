using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;
using Microsoft.Maui.ApplicationModel.Communication; //Indispensable pour le téléphone

namespace AlerteViolence.ViewModels;

public partial class ContactsViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ContactUrgence> _contacts;

    public ContactsViewModel()
    {
        var service = new DataService();
        Contacts = new ObservableCollection<ContactUrgence>(service.GetContactsCameroun());
    }

    [RelayCommand]
    private async Task ShowDetailsAsync(object? parameter)
    {
        if (parameter is ContactUrgence contact)
        {
            
            bool wantToCall = await Shell.Current.DisplayAlertAsync(
                contact.Nom,
                $"Numéro : {contact.Numero}\nDomaine : {contact.Domaine}\n\n{contact.Description}\n\nVoulez-vous composer ce numéro ?",
                "📞 Appeler",
                "Annuler");

            if (wantToCall)
            {
                try
                {
                    // Ouvre le composeur téléphonique du smartphone
                    // Nettoie le numéro en supprimant les espaces et les tirets
                    string numeroPropre = contact.Numero.Replace(" ", "").Replace("-", "");
                    PhoneDialer.Default.Open(numeroPropre);
                }
                catch (FeatureNotSupportedException)
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Non pris en charge",
                        "L'appel téléphonique ne fonctionne que sur un vrai téléphone, pas sur l'émulateur ou le PC.",
                        "OK");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Erreur",
                        $"Impossible de lancer l'appel : {ex.Message}",
                        "OK");
                }
            }
        }
    }
}