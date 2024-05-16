using CyberTech.Core.Domain.Administration;
using CyberTech.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CyberTech.DataAccess.Confirurations
{
    public class GameTeamConfiguration : IEntityTypeConfiguration<GameTeam>
    {
        public void Configure(EntityTypeBuilder<GameTeam> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<string>(e => e.Name).IsRequired().HasMaxLength(100);


            builder.HasMany(e => e.Members)
                   .WithMany(x=>x.GameTeams)
                   .UsingEntity("GameTeamUser",
                        l => l.HasOne(typeof(User))
                              .WithMany()
                              .HasForeignKey("UserId")
                              .OnDelete(DeleteBehavior.Cascade)
                              .HasPrincipalKey(nameof(User.Id)),
                        r => r.HasOne(typeof(GameTeam))
                              .WithMany()
                              .HasForeignKey("GameTeamId")
                              .OnDelete(DeleteBehavior.NoAction)
                              .HasPrincipalKey(nameof(GameTeam.Id)),
                        j => j.HasKey("UserId", "GameTeamId"));

        }
    }
}
