using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntitiesConfig
{
    public class DsSysLogSystemConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<DsSysLogSystem> entity)
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
        }
    }
}
