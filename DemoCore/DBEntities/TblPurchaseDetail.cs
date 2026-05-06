using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblPurchaseDetail
{
    public int Id { get; set; }

    public int? Poid { get; set; }

    public int? MaterialId { get; set; }

    public decimal? Price { get; set; }

    public int? Qty { get; set; }

    public decimal? Total { get; set; }

    public virtual TblMaterial? Material { get; set; }

    public virtual TblPurchaseMaster? Po { get; set; }
}
