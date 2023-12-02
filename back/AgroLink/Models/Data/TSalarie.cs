using System;
using System.Collections.Generic;

namespace AgroLink.Models.Data;

public partial class TSalarie
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string? TelephoneFixe { get; set; }

    public string? TelephoneMobile { get; set; }

    public string Email { get; set; } = null!;

    public int RefService { get; set; }

    public int RefSite { get; set; }

    public int? RefRole { get; set; }

    public virtual TRole? RefRoleNavigation { get; set; }

    public virtual TService RefServiceNavigation { get; set; } = null!;

    public virtual TSite RefSiteNavigation { get; set; } = null!;
}
