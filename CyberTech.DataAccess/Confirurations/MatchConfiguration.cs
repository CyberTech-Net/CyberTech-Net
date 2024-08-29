using CyberTech.Domain.Models.Tournaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<MatchEntity>
    {
        public void Configure(EntityTypeBuilder<MatchEntity> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Matches", "tournaments");

            entity.Property(e => e.StartDateTime).IsRequired().HasColumnType("timestamp without time zone");
            entity.Property(e => e.FirstTeamId).IsRequired();
            entity.Property(e => e.SecondTeamId).IsRequired();

            entity.HasOne(e => e.Tournament)
                   .WithMany(g => g.Matches)
                   .HasForeignKey(e => e.TournamentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
