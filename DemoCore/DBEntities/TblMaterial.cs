using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblMaterial
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? Uomid { get; set; }

    public int? Gstid { get; set; }

    public DateTime? CreateOn { get; set; }

    public virtual TblGst? Gst { get; set; }

    public virtual ICollection<TblPurchaseDetail> TblPurchaseDetails { get; set; } = new List<TblPurchaseDetail>();

    public virtual ICollection<TblSaleDetail> TblSaleDetails { get; set; } = new List<TblSaleDetail>();

    public virtual TblUom? Uom { get; set; }
}
