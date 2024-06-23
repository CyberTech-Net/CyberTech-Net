using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property<string>(e=>e.TitleTeam).IsRequired().HasMaxLength(50);
            builder.Property<DateTime>(x => x.Founded).HasDefaultValue(DateTime.Today);

        }
    }
    
}
