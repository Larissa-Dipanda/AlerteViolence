using System;
using System.Collections.Generic;
using System.Text;

namespace AlerteViolence.Models;

public class Rapport
{
    public string Numero { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Statut { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
    public string Description { get; set; } = string.Empty;
}