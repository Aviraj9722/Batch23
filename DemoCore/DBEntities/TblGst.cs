using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblGst
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TblMaterial> TblMaterials { get; set; } = new List<TblMaterial>();
}
