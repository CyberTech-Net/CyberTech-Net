using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<InfoEntity>
    {
        public void Configure(EntityTypeBuilder<InfoEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("News", "handbooks");

            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Text).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Date).HasColumnType("date");
            builder.Property(x=>x.ImageId).HasDefaultValue(string.Empty).HasMaxLength(50);
        }
    }
}
