using System;
using System.Collections.Generic;

namespace AgroLink.Models.Data;

public partial class TRole
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public virtual ICollection<TSalarie> TSalaries { get; } = new List<TSalarie>();
}
