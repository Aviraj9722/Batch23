using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblSaleDetail
{
    public int Id { get; set; }

    public int? SaleId { get; set; }

    public int? MaterialId { get; set; }

    public double? Price { get; set; }

    public int? Qty { get; set; }

    public double? Total { get; set; }

    public virtual TblMaterial? Material { get; set; }

    public virtual TblSaleMaster? Sale { get; set; }
}
