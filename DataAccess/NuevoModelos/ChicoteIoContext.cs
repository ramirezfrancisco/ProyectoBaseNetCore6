using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.NuevoModelos;

public partial class ChicoteIoContext : DbContext
{
    public ChicoteIoContext()
    {
    }

    public ChicoteIoContext(DbContextOptions<ChicoteIoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DsSysLogSystem> DsSysLogSystems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=192.168.2.12;Database=ChicoteIO;User ID=sa;Password=sa;Trusted_Connection=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DsSysLogSystem>(entity =>
        {
            entity.HasKey(e => e.IdLog);

            entity.ToTable("DsSysLogSystem");

            entity.Property(e => e.IdLog).HasColumnName("Id_Log");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.DateRegister)
                .HasColumnType("datetime")
                .HasColumnName("dateRegister");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.InnerException)
                .IsUnicode(false)
                .HasColumnName("innerException");
            entity.Property(e => e.Priority)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("priority");
            entity.Property(e => e.Service)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("service");
            entity.Property(e => e.User)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
