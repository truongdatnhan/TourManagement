using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class SachConfiguration : IEntityTypeConfiguration<Sach>
    {
        public void Configure(EntityTypeBuilder<Sach> builder)
        {
            builder.ToTable("Sach");
            builder.HasKey(s => s.MaSach);
            builder.HasOne(tg => tg.TacGia).WithMany(s => s.Sachs).HasForeignKey(tg => tg.MaTG);
            builder.HasOne(tl => tl.TheLoai).WithMany(s => s.Sachs).HasForeignKey(tl => tl.MaTL);
            builder.HasOne(nxb => nxb.NhaXuatBan).WithMany(s => s.Sachs).HasForeignKey(nxb => nxb.MaNXB);
        }
    }
}