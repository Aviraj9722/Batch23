using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblUser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? BirthDate { get; set; }

    public virtual TblRole? Role { get; set; }
}
