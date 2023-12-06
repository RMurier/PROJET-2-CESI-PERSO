using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgroLink.Models;

public class TSite
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public int RefType { get; set; }
}
