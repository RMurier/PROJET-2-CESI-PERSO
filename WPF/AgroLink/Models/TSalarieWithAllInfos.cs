using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgroLink.Models;

public partial class TSalarieWithAllInfos
{
    public int Id { get; set; }
    public string Nom { get; set; } = null!;
    public string Prenom { get; set; } = null!;
    public string? TelephoneFixe { get; set; }
    public string? TelephoneMobile { get; set; }
    public string Email { get; set; } = null!;
    public int RefService { get; set; }
    public string Service { get; set; }
    public int RefSite { get; set; }
    public string Site { get; set; }

    public int? RefRole { get; set; }
    public string Role { get; set; }
}
