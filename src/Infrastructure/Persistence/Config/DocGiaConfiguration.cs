using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence
{
    public class DocGiaConfiguration : IEntityTypeConfiguration<DocGia>
    {
        public void Configure(EntityTypeBuilder<DocGia> builder)
        {
            builder.ToTable("DocGia");
            builder.HasKey(dg => dg.MaDG);
            builder.Property(dg => dg.DoBDG).HasColumnType("Date");
            builder.Property(dg => dg.NgayDK).HasColumnType("Date");
            builder.Property(dg => dg.NgayHetHanDK).HasColumnType("Date");
        }
    }
}