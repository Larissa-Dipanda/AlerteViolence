using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AlerteViolence.Models;
using AlerteViolence.Services;
using Microsoft.Maui.ApplicationModel.Communication; // Indispensable pour le téléphone

namespace AlerteViolence.ViewModels;

public partial class SosReportViewModel : ObservableObject
{
    private readonly AlerteService _alerteService;

    [ObservableProperty]
    private string _userName = "Utilisateur";

    [ObservableProperty]
    private string _typeRapport = string.Empty;

    [ObservableProperty]
    private string _statut = string.Empty;

    public SosReportViewModel()
    {
        _alerteService = new AlerteService();
        // Récupère le nom sauvegardé lors de l'inscription/connexion
        UserName = Preferences.Default.Get("NomUtilisateur", "Utilisateur");
    }

    [RelayCommand]
    private async Task SubmitReportAsync()
    {
        // 1. Validation des champs
        if (string.IsNullOrWhiteSpace(TypeRapport) || string.IsNullOrWhiteSpace(Statut))
        {
            await Shell.Current.DisplayAlertAsync("Erreur", "Veuillez remplir tous les champs du formulaire.", "OK");
            return;
        }

        // 2. Sauvegarde du rapport dans l'historique
        var rapport = new Rapport
        {
            Numero = "En attente",
            Type = TypeRapport,
            Statut = Statut,
            Date = DateTime.Now,
            Description = "Rapport rapide avec demande d'assistance."
        };
        await _alerteService.SaveRapportAsync(rapport);

        // 3. Analyse intelligente des mots-clés pour choisir le meilleur numéro
        string texte = TypeRapport.ToLower(); // On met en minuscule pour faciliter la recherche
        string numeroRecommande = "112"; // Numéro universel par défaut
        string serviceRecommande = "Numéro d'Urgence Universel";

        if (texte.Contains("feu") || texte.Contains("incendie") || texte.Contains("brûle") || texte.Contains("fumée"))
        {
            numeroRecommande = "118";
            serviceRecommande = "Pompiers";
        }
        else if (texte.Contains("malade") || texte.Contains("blessé") || texte.Contains("sang") || texte.Contains("accident") || texte.Contains("évanoui"))
        {
            numeroRecommande = "119";
            serviceRecommande = "SAMU (Urgences Médicales)";
        }
        else if (texte.Contains("agression") || texte.Contains("viol") || texte.Contains("vol") || texte.Contains("menace") || texte.Contains("coup") || texte.Contains("harcèle"))
        {
            numeroRecommande = "117";
            serviceRecommande = "Police / Gendarmerie";
        }
        else if (texte.Contains("femme") || texte.Contains("enfant") || texte.Contains("conjugale") || texte.Contains("mariage forcé"))
        {
            numeroRecommande = "1510";
            serviceRecommande = "MINPROFF (Ligne verte VBG)";
        }

        // 4. Proposer l'appel à l'utilisateur
        bool wantToCall = await Shell.Current.DisplayAlertAsync(
            "🚨 ALERTE D'URGENCE",
            $"Votre rapport a été sauvegardé avec succès.\n\nEn fonction de votre description, le système vous recommande d'appeler le **{numeroRecommande}** ({serviceRecommande}).\n\nVoulez-vous lancer l'appel immédiatement ?",
            "📞 OUI, APPELER",
            "Non, annuler");

        // 5. Exécuter l'appel si l'utilisateur accepte
        if (wantToCall)
        {
            try
            {
                // Cette ligne ouvre le composeur du téléphone avec le numéro pré-rempli
                PhoneDialer.Default.Open(numeroRecommande);
            }
            catch (FeatureNotSupportedException)
            {
                await Shell.Current.DisplayAlertAsync("Non pris en charge", "L'appel téléphonique ne fonctionne que sur un vrai téléphone, pas sur l'émulateur ou le PC.", "OK");
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlertAsync("Erreur", "Impossible de lancer l'appel pour le moment.", "OK");
            }
        }

        // 6. Réinitialiser le formulaire après l'envoi
        TypeRapport = string.Empty;
        Statut = string.Empty;
    }
}