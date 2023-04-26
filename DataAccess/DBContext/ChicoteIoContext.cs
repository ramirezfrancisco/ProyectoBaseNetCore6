using DataAccess.Entities;
using DataAccess.EntitiesConfig;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBContext
{
    public partial class ChicoteIoContext : DbContext
    {
        private string _connectionString;
        public ChicoteIoContext()
        {
        }

        public ChicoteIoContext(string ConectionString)
        {
            _connectionString = ConectionString;
        }

        public ChicoteIoContext(DbContextOptions<ChicoteIoContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        public virtual DbSet<DsVentasCotizacionDetalle> DsVentasCotizacionDetalles { get; set; }

        public virtual DbSet<DsVentasCotizacionEncabezado> DsVentasCotizacionEncabezados { get; set; }
        public virtual DbSet<DsSysLogSystem> DsSysLogSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");
            DsVentasCotizacionEncabezadoConfig.SetEntityBuilder(modelBuilder.Entity<DsVentasCotizacionEncabezado>());
            DsVentasCotizacionDetalleConfig.SetEntityBuilder(modelBuilder.Entity<DsVentasCotizacionDetalle>());
            DsSysLogSystemConfig.SetEntityBuilder(modelBuilder.Entity<DsSysLogSystem>());
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        //{
        //   // ProcessSave();
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
