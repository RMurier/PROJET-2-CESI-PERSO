using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AgroLink.Models.Data;

public partial class TRole
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<TSalarie> TSalaries { get; } = new List<TSalarie>();
}
