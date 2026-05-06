using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblVender
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Gstn { get; set; }

    public string? Pancard { get; set; }

    public string? Contact { get; set; }

    public string? Gender { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Hobbies { get; set; }

    public string? Photo { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual TblRole? Role { get; set; }

    public virtual ICollection<TblPurchaseMaster> TblPurchaseMasters { get; set; } = new List<TblPurchaseMaster>();
}
