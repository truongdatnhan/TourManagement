using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class PhieuPhatConfiguration : IEntityTypeConfiguration<PhieuPhat>
    {
        public void Configure(EntityTypeBuilder<PhieuPhat> builder)
        {
            builder.ToTable("PhieuPhat");
            builder.HasKey(pp => pp.MaPP);
            builder.HasOne(dg => dg.DocGia).WithMany(pt => pt.PhieuPhats).HasForeignKey(dg => dg.MaDG);
            builder.HasOne(us => us.AppUser).WithMany(pp => pp.PhieuPhats).HasForeignKey(us => us.UserId);
            builder.Property(pp => pp.TrangThai).HasColumnType("Int");
        }
    }
}