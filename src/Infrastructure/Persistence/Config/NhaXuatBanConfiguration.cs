using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class NhaXuatBanConfiguration : IEntityTypeConfiguration<NhaXuatBan>
    {
        public void Configure(EntityTypeBuilder<NhaXuatBan> builder)
        {
            builder.ToTable("NhaXuatBan");
            builder.HasKey(nxb => nxb.MaNXB);
        }
    }
}