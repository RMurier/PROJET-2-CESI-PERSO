using System;
using System.Collections.Generic;

namespace AgroLink.Models.Data;

public partial class TTypeSite
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<TSite> TSites { get; } = new List<TSite>();
}
