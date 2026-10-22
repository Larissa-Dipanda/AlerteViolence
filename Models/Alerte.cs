namespace AlerteViolence.Models;

public class Alerte
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime DateHeure { get; set; } = DateTime.Now;
    public string NatureMessage { get; set; } = string.Empty;
    public string Priorite { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Localisation { get; set; }
    public bool EstEnvoyee { get; set; } = false;
}