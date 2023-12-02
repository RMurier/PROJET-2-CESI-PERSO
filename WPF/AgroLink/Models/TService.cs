using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgroLink.Models;

public partial class TService
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;
}