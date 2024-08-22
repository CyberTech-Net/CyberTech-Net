using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
    {
        public void Configure(EntityTypeBuilder<CountryEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Countries", "handbooks");

            builder.Property(e => e.TitleCountry).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ImageId).HasDefaultValue(string.Empty).HasMaxLength(50);
        }
    }

}
