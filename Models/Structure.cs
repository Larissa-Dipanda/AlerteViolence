namespace AlerteViolence.Models;

public class Structure
{
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // ex: "ONG", "Ministère"
}