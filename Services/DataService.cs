using System.Text.Json;
using AlerteViolence.Models;

namespace AlerteViolence.Services;

public class DataService
{
    /// <summary>
    /// Charge la liste des lois depuis le fichier JSON embarqué
    /// </summary>
    public async Task<List<Loi>> GetLoisAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("lois.json");
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        return JsonSerializer.Deserialize<List<Loi>>(content) ?? new List<Loi>();
    }

    /// <summary>
    /// Charge la liste des contacts d'urgence depuis le fichier JSON embarqué
    /// </summary>
    public async Task<List<ContactUrgence>> GetContactsUrgencesAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("contacts_urgences.json");
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        return JsonSerializer.Deserialize<List<ContactUrgence>>(content) ?? new List<ContactUrgence>();
    }

    /// <summary>
    /// Charge la liste des structures depuis le fichier JSON embarqué
    /// </summary>
    public async Task<List<Structure>> GetStructuresAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("structures.json");
        using var reader = new StreamReader(stream);
        var content = await reader.ReadToEndAsync();
        return JsonSerializer.Deserialize<List<Structure>>(content) ?? new List<Structure>();
    }
}