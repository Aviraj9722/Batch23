using System;
using System.Collections.Generic;

namespace DemoCore.DBEntities;

public partial class TblSaleMaster
{
    public int Id { get; set; }

    public string? CustomerName { get; set; }

    public DateTime? SaleDate { get; set; }

    public double? GrandTotal { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<TblSaleDetail> TblSaleDetails { get; set; } = new List<TblSaleDetail>();
}
