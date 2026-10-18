namespace AlerteViolence.Models;

public class ContactUrgence
{
    public string Nom { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icone { get; set; } = "police.png"; // Nom de l'image vectorielle
}