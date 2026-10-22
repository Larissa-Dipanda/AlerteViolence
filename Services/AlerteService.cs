using System.Text.Json;
using AlerteViolence.Models;

namespace AlerteViolence.Services;

public class AlerteService
{
    private const string StorageKey = "rapports_historique";

    public async Task SaveRapportAsync(Rapport rapport)
    {
        var rapports = await GetRapportsAsync();
        rapports.Insert(0, rapport); // Ajoute au début (le plus récent)

        var json = JsonSerializer.Serialize(rapports);
        await SecureStorage.Default.SetAsync(StorageKey, json);
    }

    public async Task<List<Rapport>> GetRapportsAsync()
    {
        try
        {
            var json = await SecureStorage.Default.GetAsync(StorageKey);
            if (string.IsNullOrWhiteSpace(json)) return new List<Rapport>();

            return JsonSerializer.Deserialize<List<Rapport>>(json) ?? new List<Rapport>();
        }
        catch { return new List<Rapport>(); }
    }

    public async Task DeleteAllRapportsAsync()
    {
        SecureStorage.Default.Remove(StorageKey);
        await Task.CompletedTask;
    }
}