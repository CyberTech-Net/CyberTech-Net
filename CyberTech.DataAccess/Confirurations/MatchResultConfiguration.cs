using CyberTech.Domain.Models.Tournaments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class MatchResultConfiguration : IEntityTypeConfiguration<MatchResultEntity>
    {
        public void Configure(EntityTypeBuilder<MatchResultEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MatchResults", "tournaments");

            builder.HasOne(d => d.Match)
                   .WithMany(p => p.MatchResults)
                   .HasForeignKey(d => d.MatchId)
                   .HasConstraintName("FK_Matches_To_Tournaments");

            builder.HasOne(e => e.Team)
                   .WithMany(g => g.MatchResults)
                   .HasForeignKey(e => e.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
