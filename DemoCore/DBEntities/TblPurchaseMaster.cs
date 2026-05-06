using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblPurchaseMaster
{
    public int Id { get; set; }

    public int? VenderId { get; set; }

    public DateTime? Podate { get; set; }

    public decimal? GrandTotal { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<TblPurchaseDetail> TblPurchaseDetails { get; set; } = new List<TblPurchaseDetail>();

    public virtual TblVender? Vender { get; set; }
}
