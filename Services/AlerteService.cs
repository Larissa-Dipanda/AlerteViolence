using System.Text.Json;
using AlerteViolence.Models;

namespace AlerteViolence.Services;

public class AlerteService
{
    private const string ALERTES_KEY = "alertes_historique";

    /// <summary>
    /// Envoie une alerte aux contacts de confiance (simulation pour l'instant)
    /// </summary>
    public async Task<bool> EnvoyerAlerteAsync(Alerte alerte)
    {
        try
        {
            // Récupérer la géolocalisation si autorisée
            try
            {
                var location = await Geolocation.Default.GetLocationAsync(
                    new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(10)
                    });

                if (location != null)
                {
                    alerte.Localisation = $"{location.Latitude}, {location.Longitude}";
                }
            }
            catch
            {
                // Géolocalisation non disponible, on continue sans
            }

            // Sauvegarder l'alerte dans l'historique local
            await SauvegarderAlerteAsync(alerte);

            // TODO: Envoyer SMS aux contacts de confiance
            // Pour l'instant, on simule l'envoi
            await Task.Delay(500);

            alerte.EstEnvoyee = true;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    /// Sauvegarde l'alerte dans le stockage local sécurisé
    /// </summary>
    private async Task SauvegarderAlerteAsync(Alerte alerte)
    {
        var alertes = await ObtenirHistoriqueAsync();
        alertes.Insert(0, alerte); // Ajouter au début (plus récent)

        // Limiter à 50 alertes pour ne pas surcharger
        if (alertes.Count > 50)
        {
            alertes = alertes.Take(50).ToList();
        }

        var json = JsonSerializer.Serialize(alertes);
        await SecureStorage.Default.SetAsync(ALERTES_KEY, json);
    }

    /// <summary>
    /// Récupère l'historique des alertes
    /// </summary>
    public async Task<List<Alerte>> ObtenirHistoriqueAsync()
    {
        try
        {
            var json = await SecureStorage.Default.GetAsync(ALERTES_KEY);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Alerte>();

            return JsonSerializer.Deserialize<List<Alerte>>(json) ?? new List<Alerte>();
        }
        catch
        {
            return new List<Alerte>();
        }
    }

    /// <summary>
    /// Efface tout l'historique des alertes
    /// </summary>
    public async Task EffacerHistoriqueAsync()
    {
        SecureStorage.Default.Remove(ALERTES_KEY);
        await Task.CompletedTask;
    }
}