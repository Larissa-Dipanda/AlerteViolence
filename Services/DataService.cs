using AlerteViolence.Models;

namespace AlerteViolence.Services;

public class DataService
{
    public List<Loi> GetLoisCamerounaises()
    {
        return new List<Loi>
        {
            // VIOLENCES PHYSIQUES
            new Loi { Article = "Art. 263", Titre = "Coups et blessures volontaires", Description = "Toute violence exercée contre une personne sans incapacité de travail.", Peine = "6 jours à 5 ans et amende.", LienWeb = "https://lex.cameroun.cc/fr/cm/loi-n-2019020-du-24-d-cembre-2019-modifiant-et-compl-tant-certaines-dispositions-de-la-loi", Categorie = "Violences Physiques" },
            new Loi { Article = "Art. 264", Titre = "Coups et blessures aggravés", Description = "Sur conjoint, enfant, personne vulnérable, ou avec arme.", Peine = "5 à 10 ans de prison.", LienWeb = "http://www.minjustice.gov.cm/index.php/fr/legalis/accueil-legalis", Categorie = "Violences Physiques" },
            new Loi { Article = "Art. 266", Titre = "Mutilation", Description = "Ablation ou mutilation d'un membre ou organe génital (y compris l'excision).", Peine = "10 à 20 ans de prison.", LienWeb = "https://rflgd.org/cameroun/", Categorie = "Violences Physiques" },

            // VIOLENCES SEXUELLES
            new Loi { Article = "Art. 293", Titre = "Viol", Description = "Tout acte de pénétration sexuelle commis sur autrui sans consentement.", Peine = "15 à 20 ans de prison.", LienWeb = "https://album-social.com/2026/09/29/cameroun-violences-femmes-code-penal/", Categorie = "Violences Sexuelles" },
            new Loi { Article = "Art. 295", Titre = "Agression sexuelle", Description = "Tout acte sexuel sans pénétration imposé sans consentement.", Peine = "5 à 10 ans de prison.", LienWeb = "https://album-social.com/2026/09/29/cameroun-violences-femmes-code-penal/", Categorie = "Violences Sexuelles" },

            // MENACES ET HARCÈLEMENT
            new Loi { Article = "Art. 332", Titre = "Menaces de mort ou de violences", Description = "Menaces répétées de mort, de violences ou d'attentat.", Peine = "1 à 3 ans de prison et amende.", LienWeb = "https://moukourilaw.com/cyberharcelement-et-haine-en-ligne-la-repression-du-cameroun/", Categorie = "Menaces et Harcèlement" },
            new Loi { Article = "Art. 334", Titre = "Chantage", Description = "Menace de révéler des informations sensibles pour obtenir quelque chose.", Peine = "1 à 5 ans de prison et amende.", LienWeb = "https://album-social.com/2026/09/29/cameroun-violences-femmes-code-penal/", Categorie = "Menaces et Harcèlement" },

            // PROTECTION DE L'ENFANCE
            new Loi { Article = "Art. 336", Titre = "Abandon de mineur", Description = "Abandon d'un enfant de moins de 15 ans dans un lieu non sûr.", Peine = "1 à 5 ans de prison.", LienWeb = "https://clr.africanchildforum.org/", Categorie = "Protection de l'Enfance" },

            // MARIAGES FORCÉS ET ENLÈVEMENT
            new Loi { Article = "Art. 345", Titre = "Mariage forcé", Description = "Contrainte physique ou morale pour forcer une personne à se marier.", Peine = "1 à 5 ans de prison et amende.", LienWeb = "https://www.ohchr.org/sites/default/files/Documents/Issues/Women/WRGS/Earlyforcedmarriage/SG/Cameroon.pdf", Categorie = "Mariages Forcés et Enlèvement" },

            // NON-ASSISTANCE ET DIGNITÉ
            new Loi { Article = "Art. 144", Titre = "Non-assistance à personne en danger", Description = "Ne pas porter secours à une personne en péril lorsqu'on peut le faire sans risque.", Peine = "6 mois à 5 ans et amende.", LienWeb = "http://www.minjustice.gov.cm/index.php/fr/legalis/textes-de-lois", Categorie = "Non-Assistance et Dignité" }
        };
    }

    public List<ContactUrgence> GetContactsCameroun()
    {
        return new List<ContactUrgence>
        {
            new ContactUrgence { Nom = "Numéro d'Urgence Universel", Numero = "112", Domaine = "Tous", Description = "Numéro gratuit accessible depuis tout opérateur.", LienWeb = "https://www.interieur.gov.cm" },
            new ContactUrgence { Nom = "Police (Sûreté Nationale)", Numero = "117", Domaine = "Sécurité", Description = "Intervention en zone urbaine.", LienWeb = "https://www.interieur.gov.cm" },
            new ContactUrgence { Nom = "Gendarmerie Nationale", Numero = "117", Domaine = "Sécurité", Description = "Intervention en zone rurale.", LienWeb = "https://www.interieur.gov.cm" },
            new ContactUrgence { Nom = "SAMU", Numero = "119", Domaine = "Santé", Description = "Aide Médicale d'Urgence.", LienWeb = "https://www.sante.gov.cm" },
            new ContactUrgence { Nom = "Pompiers", Numero = "118", Domaine = "Urgence", Description = "Incendies et sauvetages.", LienWeb = "https://www.protectioncivile.gov.cm" },
            new ContactUrgence { Nom = "MINPROFF (Centre d'écoute)", Numero = "1510", Domaine = "VBG", Description = "Numéro vert pour les femmes victimes de VBG.", LienWeb = "https://www.minproff.gov.cm" },
            new ContactUrgence { Nom = "Ligne Enfants (UNICEF)", Numero = "116", Domaine = "Enfance", Description = "Numéro gratuit pour enfants en danger.", LienWeb = "https://www.unicef.org/cameroon" }
        };
    }

    public List<Structure> GetStructuresCameroun()
    {
        return new List<Structure>
        {
            new Structure { Nom = "MINPROFF",Adresse = "Yaoundé (Siège) et 10 régions", Description = "Ministère de la Promotion de la Femme et de la Famille.", Telephone = "+237 222 22 03 43", LienWeb = "https://www.minproff.gov.cm" },
            new Structure { Nom = "CENAME", Adresse = "Yaoundé - Bastos", Description = "Centre National de l'Enfance. Protection des mineurs.", Telephone = "+237 222 20 50 50", LienWeb = "https://www.cename.cm" },
            new Structure { Nom = "ALUVI", Adresse = "Yaoundé / Douala", Description = "Association de Lutte contre les Violences faites aux Femmes.", Telephone = "+237 699 99 99 99", LienWeb = "https://aluvi.org" },
            new Structure { Nom = "AFJ", Adresse = "Yaoundé", Description = "Association des Femmes Juristes du Cameroun.", Telephone = "+237 677 33 33 33", LienWeb = "https://afjcameroun.org" }
        };
    }
}