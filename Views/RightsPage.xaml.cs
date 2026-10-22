using System.Collections.ObjectModel;
using AlerteViolence.Models;

namespace AlerteViolence.Views;

public partial class RightsPage : ContentPage
{
    public ObservableCollection<Loi> Lois { get; set; } = new();

    public RightsPage()
    {
        InitializeComponent();
        BindingContext = this;
        ChargerLoisCamerounaises();
    }

    private void ChargerLoisCamerounaises()
    {
        // VIOLENCES PHYSIQUES
        Lois.Add(new Loi { Article = "Art. 263", Titre = "Coups et blessures volontaires", Description = "Toute violence exercée contre une personne sans incapacité de travail.", Peine = "6 jours à 5 ans et amende.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 264", Titre = "Coups et blessures aggravés", Description = "Sur conjoint, enfant, personne vulnérable, ou avec arme.", Peine = "5 à 10 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 266", Titre = "Mutilation", Description = "Ablation ou mutilation d'un membre ou organe génital (y compris l'excision).", Peine = "10 à 20 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });

        // VIOLENCES SEXUELLES
        Lois.Add(new Loi { Article = "Art. 293", Titre = "Viol", Description = "Tout acte de pénétration sexuelle commis sur autrui sans consentement.", Peine = "15 à 20 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 293 al. 2", Titre = "Viol aggravé", Description = "Viol sur mineur de moins de 18 ans, personne vulnérable, ou en réunion.", Peine = "Réclusion criminelle à perpétuité.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 295", Titre = "Agression sexuelle", Description = "Tout acte sexuel sans pénétration imposé sans consentement.", Peine = "5 à 10 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 297", Titre = "Harcèlement sexuel", Description = "Pressions ou comportements répétés à connotation sexuelle.", Peine = "1 à 5 ans de prison et amende.", LienWeb = "https://www.minjustice.gov.cm" });

        // MENACES ET HARCÈLEMENT
        Lois.Add(new Loi { Article = "Art. 332", Titre = "Menaces de mort ou de violences", Description = "Menaces répétées de mort, de violences ou d'attentat.", Peine = "1 à 3 ans de prison et amende.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 334", Titre = "Chantage", Description = "Menace de révéler des informations sensibles pour obtenir quelque chose.", Peine = "1 à 5 ans de prison et amende.", LienWeb = "https://www.minjustice.gov.cm" });

        // PROTECTION DE L'ENFANCE
        Lois.Add(new Loi { Article = "Art. 336", Titre = "Abandon de mineur", Description = "Abandon d'un enfant de moins de 15 ans dans un lieu non sûr.", Peine = "1 à 5 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 338", Titre = "Mise en danger d'enfants", Description = "Exposition d'un mineur à des situations dangereuses (mendicité, prostitution).", Peine = "5 à 10 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });

        // MARIAGES FORCÉS ET ENLÈVEMENT
        Lois.Add(new Loi { Article = "Art. 345", Titre = "Mariage forcé", Description = "Contrainte physique ou morale pour forcer une personne à se marier.", Peine = "1 à 5 ans de prison et amende.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 346", Titre = "Enlèvement et séquestration", Description = "Détention ou enlèvement d'une personne sans son consentement.", Peine = "5 à 10 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });

        // NON-ASSISTANCE ET DIGNITÉ
        Lois.Add(new Loi { Article = "Art. 144", Titre = "Non-assistance à personne en danger", Description = "Ne pas porter secours à une personne en péril lorsqu'on peut le faire sans risque.", Peine = "6 mois à 5 ans et amende.", LienWeb = "https://www.minjustice.gov.cm" });
        Lois.Add(new Loi { Article = "Art. 146", Titre = "Atteinte à la dignité", Description = "Traitement cruel, inhumain ou dégradant envers une personne.", Peine = "1 à 10 ans de prison.", LienWeb = "https://www.minjustice.gov.cm" });
    }

    private async void OnLoiClicked(object sender, TappedEventArgs e)
    {
        if (e.Parameter is Loi loi)
        {
            // Utilisation de DisplayAlertAsync (compatible .NET 9/10)
            await DisplayAlertAsync(loi.Article, $"{loi.Titre}\n\n{loi.Description}\n\n⚖️ Peine : {loi.Peine}\n\n🔗 Lien : {loi.LienWeb}", "Fermer");
        }
    }
}