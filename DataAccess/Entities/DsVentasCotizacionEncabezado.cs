using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class DsVentasCotizacionEncabezado
{
    public string SalesId { get; set; } = null!;

    public int Empresa { get; set; }

    public int NumeroCotizacion { get; set; }

    public string? CustAccount { get; set; }

    public string? CustName { get; set; }

    public string? CustPaymMode { get; set; }

    public string? CustPaymTermId { get; set; }

    public string? CsTaxTypeDocumentId { get; set; }

    public string? CustInvoiceAccount { get; set; }

    public string? CurrencyCode { get; set; }

    public string? InventSiteId { get; set; }

    public string? InventLocationId { get; set; }

    public DateTime? SalesReceiptDateRequested { get; set; }

    public DateTime? SalesShippingDateRequested { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public string? CustDlvModeId { get; set; }

    public string? CustDlvTermId { get; set; }

    public string? SalesPoolId { get; set; }

    public string? CommissSalesGroup { get; set; }

    public string? SalesOriginId { get; set; }

    public string? SalesTaker { get; set; }

    public string? WorkerSalesResponsible { get; set; }

    public string? SalesUnit { get; set; }

    public string? LanguageId { get; set; }

    public string? CustPurchaseOrder { get; set; }

    public string? CustRef { get; set; }

    public string? SalesStatus { get; set; }

    public long? PostalAddressRecId { get; set; }

    public decimal? TotalCajas { get; set; }

    public decimal? TotalDocenas { get; set; }

    public string? Observaciones { get; set; }

    public string? SalesOrderNumber { get; set; }

    public long? PostalInvoiceAddressRecId { get; set; }

    public DateTime? UltimaModificacion { get; set; }

    public string? WorkerSalesCreator { get; set; }

    public bool? IsSpecial { get; set; }

    public string? WorkerAuthorize { get; set; }

    public DateTime? DateAuthorize { get; set; }

    public virtual ICollection<DsVentasCotizacionDetalle> DsVentasCotizacionDetalles { get; } = new List<DsVentasCotizacionDetalle>();
}
