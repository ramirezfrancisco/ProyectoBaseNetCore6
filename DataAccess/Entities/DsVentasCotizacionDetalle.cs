using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class DsVentasCotizacionDetalle
{
    public string SalesId { get; set; } = null!;

    public int LineNum { get; set; }

    public int Sucursal { get; set; }

    public int? Bodega { get; set; }

    public string ItemId { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string SalesUnit { get; set; } = null!;

    public decimal SalesPrice { get; set; }

    public decimal PriceUnit { get; set; }

    public decimal LineDisc { get; set; }

    public decimal LineAmount { get; set; }

    public decimal DeliveryNow { get; set; }

    public decimal Remain { get; set; }

    public string InventDimid { get; set; } = null!;

    public string ConfigId { get; set; } = null!;

    public string StyleId { get; set; } = null!;

    public string ColorId { get; set; } = null!;

    public string SizeId { get; set; } = null!;

    public string InventSiteId { get; set; } = null!;

    public string InventLocationId { get; set; } = null!;

    public string WmslocationId { get; set; } = null!;

    public string InventBatchId { get; set; } = null!;

    public string InventStatusId { get; set; } = null!;

    public decimal Factor { get; set; }

    public string? RotuloLinea { get; set; }

    public string? NombreBodega { get; set; }

    public long? PostalAddressRecId { get; set; }

    public string? DlvModeId { get; set; }

    public decimal? UnitPrice { get; set; }

    public decimal? OriginalSalesPrice { get; set; }

    public string? UnidadDeInventario { get; set; }

    public string? SalesOrderNumber { get; set; }

    public virtual DsVentasCotizacionEncabezado Sales { get; set; } = null!;
}
