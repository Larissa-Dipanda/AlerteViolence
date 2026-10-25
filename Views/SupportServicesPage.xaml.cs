using AlerteViolence.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.ApplicationModel.Communication; //  INDISPENSABLE pour le téléphone et le navigateur

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
        Structures.Add(new Structure { Nom = "CENAME", Adresse = "Yaoundé - Bastos", Description = "Centre National de l'Enfance. Protection des mineurs en danger et gestion de la ligne 116.", Telephone = "22 23 29 20", LienWeb = "https://fr.businesslist.co.cm/company/132187/centrale-nationale-dapprovisionnement-en-medicaments-essentiels-cename" });
        Structures.Add(new Structure { Nom = "MINDDEVEL", Adresse = "Yaoundé", Description = "Ministère du Développement Social. Aide sociale aux personnes vulnérables.", Telephone = "+237 697 751 591", LienWeb = "https://www.minddevel.gov.cm" });
        Structures.Add(new Structure { Nom = "Unités Médico-Judiciaires", Adresse = "CHU Yaoundé, Hôpital Général, Hôpital Laquintinie (Douala)", Description = "Constats médicaux, soins et certificats médicaux judiciaires pour les victimes.", Telephone = "+237 233 421 760", LienWeb = "https://www.sante.gov.cm" });

        // ONG et Associations
        Structures.Add(new Structure { Nom = "ALVF", Adresse = "Yaoundé / Douala", Description = "Association de Lutte contre les Violences faites aux Femmes. Assistance juridique et psychologique.", Telephone = "+237 676 89 49 67", LienWeb = "https://www.alvf-centre.org/" });
        Structures.Add(new Structure { Nom = "ACAFEJ", Adresse = "Yaoundé", Description = "Association des Femmes Juristes du Cameroun. Assistance judiciaire gratuite et conseils.", Telephone = "+237 699 98 11 79", LienWeb = "https://www.osidimbea.cm/associations/fondations-assos/acafej/" });
        Structures.Add(new Structure { Nom = "SWAA Cameroun", Adresse = "Yaoundé / Douala", Description = "Stop Violence Against Women. Soutien aux survivantes de viol et sensibilisation.", Telephone = "+237 679 46 35 40", LienWeb = "https://swaacameroon.org" });
        Structures.Add(new Structure { Nom = "CEOJ", Adresse = "Yaoundé", Description = "Centre d'Écoute et d'Orientation Juridique. Écoute active et orientation gratuite.", Telephone = "+237 699693295", LienWeb = "https://sansbarrierescameroun.org/" });

        // Structures Juridiques Gratuites
        Structures.Add(new Structure { Nom = "Bureaux d'Aide aux Victimes", Adresse = "Tous les Tribunaux de Première Instance", Description = "Accueil et orientation gratuite des victimes au sein des palais de justice.", Telephone = "+237 33 58 14 12", LienWeb = "http://minjustice.gov.cm/index.php/fr/" });
        Structures.Add(new Structure { Nom = "Cliniques Juridiques Universitaires", Adresse = "Universités de Yaoundé II, Douala, Dschang", Description = "Assistance juridique gratuite dispensée par des étudiants en droit supervisés.", Telephone = "", LienWeb = "" });
    }

    //  Utilisation de DisplayActionSheetAsync pour offrir de VRAIS boutons d'action
    private async void OnStructureClicked(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is Structure structure)
        {
            // 1. On affiche les infos et on propose 2 actions
            string action = await DisplayActionSheetAsync(
                $"{structure.Nom}\n\n📍 {structure.Adresse}\n\n{structure.Description}",
                "Annuler", // Bouton pour fermer
                null,
                "📞 Appeler ce numéro", // Bouton d'action 1
                "🌐 Ouvrir le site web" // Bouton d'action 2
            );

            // 2. On exécute l'action choisie par l'utilisateur
            if (action == "📞 Appeler ce numéro" && !string.IsNullOrWhiteSpace(structure.Telephone))
            {
                try
                {
                    //  Cette ligne ouvre le composeur téléphonique du smartphone
                    PhoneDialer.Default.Open(structure.Telephone);
                }
                catch (Exception)
                {
                    await DisplayAlertAsync("Erreur", "Impossible d'appeler. Cette fonction ne marche que sur un vrai téléphone, pas sur l'émulateur ou le PC.", "OK");
                }
            }
            else if (action == "🌐 Ouvrir le site web" && !string.IsNullOrWhiteSpace(structure.LienWeb))
            {
                try
                {
                    // Cette ligne ouvre le navigateur (Chrome, Safari, etc.)
                    await Browser.Default.OpenAsync(structure.LienWeb, BrowserLaunchMode.SystemPreferred);
                }
                catch (Exception)
                {
                    await DisplayAlertAsync("Erreur", "Impossible d'ouvrir le lien.", "OK");
                }
            }
        }
    }
}