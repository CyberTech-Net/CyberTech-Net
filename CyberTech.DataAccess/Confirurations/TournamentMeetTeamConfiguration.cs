using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CyberTech.DataAccess.Confirurations
{
    public class TournamentMeetTeamConfiguration : IEntityTypeConfiguration<TournamentMeetTeamEntity>
    {
        public void Configure(EntityTypeBuilder<TournamentMeetTeamEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EarndTeam).HasPrecision(10, 2);
            builder.Property(x => x.EarndTeam).HasDefaultValue(0.0);
            builder.Property<decimal>(x => x.ScoreTeam).HasDefaultValue(0.0);
            builder.Property<decimal>(x => x.RatingTeam).HasDefaultValue(0.0);
            builder.Property(x => x.Win).HasDefaultValue(false);

            builder.HasOne(e => e.TournamentMeet)
                   .WithMany(g => g.TournamentMeetTeams)
                   .HasForeignKey(e => e.TournamentMeetId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Team)
                   .WithMany(g => g.TournamentMeetTeams)
                   .HasForeignKey(e => e.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
