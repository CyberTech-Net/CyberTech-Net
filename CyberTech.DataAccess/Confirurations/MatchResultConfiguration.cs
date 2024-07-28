using CyberTech.Domain.Models.Tournaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class MatchResultConfiguration : IEntityTypeConfiguration<MatchResult>
    {
        public void Configure(EntityTypeBuilder<MatchResult> builder)
        {
            builder.HasKey(e => e.Id).HasName("MatchResults_pkey");

            builder.ToTable("MatchResults", "tournaments");

            builder.HasOne(d => d.Match).WithMany(p => p.MatchResults)
                .HasForeignKey(d => d.MatchId)
                .HasConstraintName("FK_Matches_To_Tournaments");

            builder.HasOne(e => e.Team)
                   .WithMany(g => g.TournamentMeetTeams)
                   .HasForeignKey(e => e.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
