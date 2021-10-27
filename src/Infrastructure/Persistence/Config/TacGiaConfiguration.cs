using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class TacGiaConfiguration : IEntityTypeConfiguration<TacGia>
    {
        public void Configure(EntityTypeBuilder<TacGia> builder)
        {
            builder.ToTable("TacGia");
            builder.HasKey(tg => tg.MaTG);
            builder.Property(tg => tg.TenTG).HasMaxLength(50).IsRequired();
        }
    }
}