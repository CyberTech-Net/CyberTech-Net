using CyberTech.Domain.Models.Tournaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> entity)
        {
            entity.HasKey(e => e.Id).HasName("Matches_pkey");

            entity.ToTable("Matches", "tournaments");

            entity.Property(e => e.StartDateTime).IsRequired().HasColumnType("timestamp without time zone");
            entity.Property(e => e.FirtstTeamId).IsRequired();
            entity.Property(e => e.SecondTeamId).IsRequired();

            entity.HasOne(e => e.Tournament)
                   .WithMany(g => g.Matches)
                   .HasForeignKey(e => e.TournamentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
