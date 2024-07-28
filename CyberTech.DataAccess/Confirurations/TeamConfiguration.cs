using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("Teams", "handbooks");

            builder.Property(e=>e.TitleTeam).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Founded);

        }
    }
    
}
