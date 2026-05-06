using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblRole
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();

    public virtual ICollection<TblVender> TblVenders { get; set; } = new List<TblVender>();
}
