using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntitiesConfig
{
    public class DsVentasCotizacionDetalleConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<DsVentasCotizacionDetalle> entity)
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
        }
    }
}
