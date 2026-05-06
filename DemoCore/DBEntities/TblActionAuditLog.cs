using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblActionAuditLog
{
    public int Id { get; set; }

    public string? ControllerName { get; set; }

    public string? ActionName { get; set; }

    public string? UserId { get; set; }

    public string? CreatedOn { get; set; }

    public string? RoutValues { get; set; }

    public string? ErrorMessage { get; set; }

    public string? Operation { get; set; }
}
