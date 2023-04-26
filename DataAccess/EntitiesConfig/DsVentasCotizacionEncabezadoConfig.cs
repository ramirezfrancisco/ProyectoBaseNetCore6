using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntitiesConfig
{
    public class DsVentasCotizacionEncabezadoConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<DsVentasCotizacionEncabezado> entity)
        {
            entity.HasKey(e => e.SalesId);

            entity.ToTable("DsVentasCotizacionEncabezado", tb => tb.HasTrigger("TgrInsCotEncabezado"));

            entity.HasIndex(e => new { e.CreatedDateTime, e.SalesId, e.NumeroCotizacion, e.UltimaModificacion }, "NonClusteredIndex-20210728-163331");

            entity.Property(e => e.SalesId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CommissSalesGroup)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");
            entity.Property(e => e.CsTaxTypeDocumentId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustAccount)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustDlvModeId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustDlvTermId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustInvoiceAccount)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CustPaymMode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustPaymTermId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustPurchaseOrder)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustRef)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DateAuthorize).HasColumnType("datetime");
            entity.Property(e => e.Empresa).HasColumnName("empresa");
            entity.Property(e => e.InventLocationId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InventSiteId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LanguageId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroCotizacion).HasColumnName("numeroCotizacion");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SalesOrderNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesOriginId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesPoolId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesReceiptDateRequested).HasColumnType("datetime");
            entity.Property(e => e.SalesShippingDateRequested).HasColumnType("datetime");
            entity.Property(e => e.SalesStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesTaker)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SalesUnit)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalCajas).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TotalDocenas).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.UltimaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("ultimaModificacion");
            entity.Property(e => e.WorkerAuthorize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WorkerSalesCreator)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.WorkerSalesResponsible)
                .HasMaxLength(20)
                .IsUnicode(false);

        }
    }
}
