using System.Collections.ObjectModel;
using AlerteViolence.Models;

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
        Contacts.Add(new ContactUrgence { Nom = "Numéro d'Urgence Universel", Numero = "112", Description = "Numéro gratuit accessible depuis tout opérateur. Redirige vers Police, Gendarmerie ou SAMU.", LienWeb = "https://www.interieur.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "Police (Sûreté Nationale)", Numero = "117", Description = "Intervention en zone urbaine pour flagrant délit, agression ou vol.", LienWeb = "https://www.interieur.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "Gendarmerie Nationale", Numero = "117", Description = "Intervention en zone péri-urbaine, rurale et sur les routes.", LienWeb = "https://www.interieur.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "SAMU", Numero = "119", Description = "Service d'Aide Médicale d'Urgence. Intervention médicale rapide.", LienWeb = "https://www.sante.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "Pompiers", Numero = "118", Description = "Brigade des sapeurs-pompiers. Incendies, accidents et sauvetages.", LienWeb = "https://www.protectioncivile.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "MINPROFF (Centre d'écoute)", Numero = "1510", Description = "Numéro vert gratuit pour les femmes et enfants victimes de VBG.", LienWeb = "https://www.minproff.gov.cm" });
        Contacts.Add(new ContactUrgence { Nom = "Ligne d'Assistance Enfants", Numero = "116", Description = "Child Helpline Cameroun. Numéro gratuit pour enfants en détresse (UNICEF).", LienWeb = "https://www.unicef.org/cameroon" });
        Contacts.Add(new ContactUrgence { Nom = "Croix-Rouge Camerounaise", Numero = "+237 222 23 23 23", Description = "Assistance humanitaire, soutien psychologique et premiers secours.", LienWeb = "https://www.croixrouge.cm" });
    }

    private async void OnContactClicked(object sender, TappedEventArgs e)
    {
        if (e.Parameter is ContactUrgence contact)
        {
            await DisplayAlertAsync(contact.Nom, $"{contact.Numero}\n\n{contact.Description}\n\n🔗 Lien : {contact.LienWeb}", "Fermer");
        }
    }
}