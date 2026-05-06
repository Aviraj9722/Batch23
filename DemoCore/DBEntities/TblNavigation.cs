using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblNavigation
{
    public int Id { get; set; }

    public string LinkText { get; set; } = null!;

    public string ControllerName { get; set; } = null!;

    public string ActionName { get; set; } = null!;

    public bool? Status { get; set; }

    public int? SequenceNo { get; set; }
}
