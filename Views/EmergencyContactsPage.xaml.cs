using AlerteViolence.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.ApplicationModel.Communication;

namespace AlerteViolence.Views;

public partial class EmergencyContactsPage : ContentPage
{
    public ObservableCollection<ContactUrgence> Contacts { get; set; } = new();

    public EmergencyContactsPage()
    {
        InitializeComponent();
        BindingContext = this;
        ChargerContactsCameroun();
    }

    private void ChargerContactsCameroun()
    {
        Contacts.Add(new ContactUrgence { Nom = "Numéro d'Urgence Universel", Numero = "112", Domaine = "Tous", Description = "Numéro gratuit accessible depuis tout opérateur.", LienWeb = "https://saropa.com/fr/emergency-cm/" });
        Contacts.Add(new ContactUrgence { Nom = "Police (Sûreté Nationale)", Numero = "117", Domaine = "Sécurité", Description = "Intervention en zone urbaine.", LienWeb = "https://www.dgsn.cm/" });
        Contacts.Add(new ContactUrgence { Nom = "Gendarmerie Nationale", Numero = "117", Domaine = "Sécurité", Description = "Intervention en zone rurale.", LienWeb = "https://emergencynumbers.org/country/CM/" });
        Contacts.Add(new ContactUrgence { Nom = "SAMU", Numero = "119", Domaine = "Santé", Description = "Aide Médicale d'Urgence.", LienWeb = "https://www.sante.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "Pompiers", Numero = "118", Domaine = "Urgence", Description = "Incendies et sauvetages.", LienWeb = "https://mindef.gov.cm/sapeurs-pompiers/" });
        Contacts.Add(new ContactUrgence { Nom = "MINPROFF", Numero = "1510", Domaine = "VBG", Description = "Numéro vert pour les femmes victimes de VBG.", LienWeb = "https://www.minproff.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "Ligne Enfants (UNICEF)", Numero = "116", Domaine = "Enfance", Description = "Numéro gratuit pour enfants en détresse.", LienWeb = "https://www.unicef.org/cameroon" });
        Contacts.Add(new ContactUrgence { Nom = "Croix-Rouge Camerounaise", Numero = "+237 222 23 23 23", Domaine = "Urgence", Description = "Assistance humanitaire.", LienWeb = "https://www.ifrc.org/fr/national-societies-directory/croix-rouge-camerounaise" });
    }

    private async void OnContactClicked(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is ContactUrgence contact)
        {
            // Utilisation de DisplayActionSheetAsync
            string action = await DisplayActionSheetAsync(
                $"{contact.Nom}\nNuméro : {contact.Numero}\nDomaine : {contact.Domaine}\n\n{contact.Description}",
                "Annuler",
                null,
                "📞 Appeler ce numéro",
                "🌐 Ouvrir le site web"
            );

            if (action == "📞 Appeler ce numéro")
            {
                try
                {
                    PhoneDialer.Default.Open(contact.Numero);
                }
                catch (Exception) //  Suppression de 'ex' pour éviter l'avertissement "variable inutilisée"
                {
                    await DisplayAlertAsync("Erreur", "Impossible d'appeler. Testez sur un vrai téléphone.", "OK");
                }
            }
            else if (action == "🌐 Ouvrir le site web")
            {
                try
                {
                    await Browser.Default.OpenAsync(contact.LienWeb, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception) 
                {
                    await DisplayAlertAsync("Erreur", "Impossible d'ouvrir le lien.", "OK");
                }
            }
        }
    }
}