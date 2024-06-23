using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class TeamPlayerConfiguration : IEntityTypeConfiguration<TeamPlayerEntity>
    {
        public void Configure(EntityTypeBuilder<TeamPlayerEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Year1).IsRequired();
            builder.Property(e => e.TeamId).IsRequired();

            builder.HasOne(e => e.Team)
                   .WithMany(g => g.TeamPlayers)
                   .HasForeignKey(e => e.TeamId)
                   .IsRequired();

            builder.HasOne(e => e.Player)
                   .WithMany(g => g.TeamPlayers)
                   .HasForeignKey(e => e.PlayerId)
                   .IsRequired();

        }
    }

}
