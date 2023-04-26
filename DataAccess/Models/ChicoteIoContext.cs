using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class ChicoteIoContext : DbContext
{
    public ChicoteIoContext()
    {
    }

    public ChicoteIoContext(DbContextOptions<ChicoteIoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DsVentasCotizacionDetalle> DsVentasCotizacionDetalles { get; set; }

    public virtual DbSet<DsVentasCotizacionEncabezado> DsVentasCotizacionEncabezados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.2.12;Database=ChicoteIO;User ID=sa;Password=sa;Trusted_Connection=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DsVentasCotizacionDetalle>(entity =>
        {
            entity.HasKey(e => new { e.SalesId, e.LineNum });

            entity.ToTable("DsVentasCotizacionDetalle", tb =>
                {
                    tb.HasTrigger("TgrInsCotizacionDetalle");
                    tb.HasTrigger("TgrInsCotizacionDetalle_BK");
                    tb.HasTrigger("TgrInsCotizacionDetalle_bk_01_11_22");
                    tb.HasTrigger("TgrInsCotizacionDetalle_bk_24_11_22");
                });

            entity.Property(e => e.SalesId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Bodega).HasColumnName("bodega");
            entity.Property(e => e.ColorId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ConfigId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DeliveryNow).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.DlvModeId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Factor).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.InventBatchId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InventDimid)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InventLocationId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InventSiteId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InventStatusId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ItemId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LineAmount).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.LineDisc).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.NombreBodega)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OriginalSalesPrice).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.PriceUnit).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.Quantity).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.Remain).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.RotuloLinea)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SalesOrderNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("salesOrderNumber");
            entity.Property(e => e.SalesPrice).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.SalesUnit)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SizeId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StyleId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sucursal).HasColumnName("sucursal");
            entity.Property(e => e.UnidadDeInventario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("unidadDeInventario");
            entity.Property(e => e.UnitPrice).HasColumnType("numeric(12, 2)");
            entity.Property(e => e.WmslocationId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WMSLocationId");

            entity.HasOne(d => d.Sales).WithMany(p => p.DsVentasCotizacionDetalles)
                .HasForeignKey(d => d.SalesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DsVentasCotizacionDetalle_DsVentasCotizacionEncabezado");
        });

        modelBuilder.Entity<DsVentasCotizacionEncabezado>(entity =>
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
