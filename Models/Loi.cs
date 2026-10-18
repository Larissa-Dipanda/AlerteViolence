namespace AlerteViolence.Models;

public class Loi
{
    public string Article { get; set; } = string.Empty;
    public string Titre { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Peine { get; set; } = string.Empty;
    public string Categorie { get; set; } = string.Empty;
    public string LienWeb { get; set; } = string.Empty; // lien vers page web pour plus d'infos
}