using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class PhieuMuonConfiguration : IEntityTypeConfiguration<PhieuMuon>
    {
        public void Configure(EntityTypeBuilder<PhieuMuon> builder)
        {
            builder.ToTable("PhieuMuon");
            builder.HasKey(pm => pm.MaPM);
            builder.HasOne(dg => dg.DocGia).WithMany(pm => pm.PhieuMuons).HasForeignKey(dg => dg.MaDG);
            builder.Property(pm => pm.NgayMuon).HasColumnType("Date");
            builder.HasOne(us => us.AppUser).WithMany(pm => pm.PhieuMuons).HasForeignKey(pm => pm.UserId);
            builder.Property(pm => pm.TrangThai).HasColumnType("Int");
        }
    }
}