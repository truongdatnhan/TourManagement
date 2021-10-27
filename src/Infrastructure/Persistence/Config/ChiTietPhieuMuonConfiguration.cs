using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class ChiTietPhieuMuonConfiguration : IEntityTypeConfiguration<ChiTietPhieuMuon>
    {
        public void Configure(EntityTypeBuilder<ChiTietPhieuMuon> builder)
        {
            builder.ToTable("ChiTietPhieuMuon");
            builder.HasKey(ctpm => new { ctpm.MaPM, ctpm.MaSach });
            builder.HasOne(pm => pm.PhieuMuon).WithMany(ctpm => ctpm.ChiTietPhieuMuons).HasForeignKey(pm => pm.MaPM);
            builder.HasOne(s => s.Sach).WithMany(ctpm => ctpm.ChiTietPhieuMuons).HasForeignKey(s => s.MaSach);
            builder.Property(ctpm => ctpm.NgayHetHan).HasColumnType("Date");
            builder.Property(ctpm => ctpm.GiaHan).HasColumnType("Date");
        }
    }
}