using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblMaterialLog
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? Uomid { get; set; }

    public int? Gstid { get; set; }

    public DateTime? CreateOn { get; set; }

    public int RecordId { get; set; }

    public string Operation { get; set; } = null!;

    public DateTime OpearationDate { get; set; }
}
