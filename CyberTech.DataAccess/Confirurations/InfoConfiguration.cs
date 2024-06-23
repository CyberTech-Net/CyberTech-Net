using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class InfoConfiguration : IEntityTypeConfiguration<InfoEntity>
    {
        public void Configure(EntityTypeBuilder<InfoEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<string>(x => x.TitleInfo).IsRequired().HasMaxLength(50);
            builder.Property<string>(x => x.TextInfo).IsRequired().HasMaxLength(500);
            builder.Property<DateTime>(x=>x.DataInfo).HasDefaultValue(DateTime.Today);
        }
    }
}
