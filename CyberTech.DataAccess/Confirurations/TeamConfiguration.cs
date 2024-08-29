using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("Teams", "handbooks");

            builder.Property(e=>e.TitleTeam).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Founded).IsRequired().HasColumnType("date");
            builder.Property(x => x.ImageId).HasDefaultValue(string.Empty).HasMaxLength(50);
        }
    }
    
}
