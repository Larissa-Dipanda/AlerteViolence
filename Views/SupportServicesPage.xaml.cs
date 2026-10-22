using System.Collections.ObjectModel;
using AlerteViolence.Models;

namespace AlerteViolence.Views;

public partial class SupportServicesPage : ContentPage
{
    public ObservableCollection<Structure> Structures { get; set; } = new();

    public SupportServicesPage()
    {
        InitializeComponent();
        BindingContext = this;
        ChargerStructuresCameroun();
    }

    private void ChargerStructuresCameroun()
    {
        // Structures Gouvernementales
        Structures.Add(new Structure { Nom = "MINPROFF", Adresse = "Yaoundé (Siège) et 10 régions", Description = "Ministère de la Promotion de la Femme et de la Famille. Centres d'écoute et d'orientation.", Telephone = "+237 222 22 03 43", LienWeb = "https://www.minproff.gov.cm" });
        Structures.Add(new Structure { Nom = "CENAME", Adresse = "Yaoundé - Bastos", Description = "Centre National de l'Enfance. Protection des mineurs en danger et gestion de la ligne 116.", Telephone = "+237 222 20 50 50", LienWeb = "https://www.cename.cm" });
        Structures.Add(new Structure { Nom = "MINDDEVEL", Adresse = "Yaoundé", Description = "Ministère du Développement Social. Aide sociale aux personnes vulnérables.", Telephone = "+237 222 22 00 00", LienWeb = "https://www.minddevel.gov.cm" });
        Structures.Add(new Structure { Nom = "Unités Médico-Judiciaires", Adresse = "CHU Yaoundé, Hôpital Général, Hôpital Laquintinie (Douala)", Description = "Constats médicaux, soins et certificats médicaux judiciaires pour les victimes.", Telephone = "", LienWeb = "https://www.sante.gov.cm" });

        // ONG et Associations
        Structures.Add(new Structure { Nom = "ALUVI", Adresse = "Yaoundé / Douala", Description = "Association de Lutte contre les Violences faites aux Femmes. Assistance juridique et psychologique.", Telephone = "+237 699 99 99 99", LienWeb = "https://aluvi.org" });
        Structures.Add(new Structure { Nom = "AFJ", Adresse = "Yaoundé", Description = "Association des Femmes Juristes du Cameroun. Assistance judiciaire gratuite et conseils.", Telephone = "+237 677 33 33 33", LienWeb = "https://afjcameroun.org" });
        Structures.Add(new Structure { Nom = "SWAA Cameroun", Adresse = "Yaoundé / Douala", Description = "Stop Violence Against Women. Soutien aux survivantes de viol et sensibilisation.", Telephone = "+237 670 00 00 00", LienWeb = "https://swaacameroon.org" });
        Structures.Add(new Structure { Nom = "CEOJ", Adresse = "Yaoundé", Description = "Centre d'Écoute et d'Orientation Juridique. Écoute active et orientation gratuite.", Telephone = "", LienWeb = "" });

        // Structures Juridiques Gratuites
        Structures.Add(new Structure { Nom = "Bureaux d'Aide aux Victimes", Adresse = "Tous les Tribunaux de Première Instance", Description = "Accueil et orientation gratuite des victimes au sein des palais de justice.", Telephone = "", LienWeb = "https://www.minjustice.gov.cm" });
        Structures.Add(new Structure { Nom = "Cliniques Juridiques Universitaires", Adresse = "Universités de Yaoundé II, Douala, Dschang", Description = "Assistance juridique gratuite dispensée par des étudiants en droit supervisés.", Telephone = "", LienWeb = "" });
    }

    private async void OnStructureClicked(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Structure structure)
        {
            await DisplayAlertAsync(structure.Nom, $"{structure.Adresse}\n\n{structure.Description}\n\nTél : {structure.Telephone}\n\nLien : {structure.LienWeb}", "Fermer");
        }
    }
}