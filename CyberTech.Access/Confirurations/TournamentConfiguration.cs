using CyberTech.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CyberTech.DataAccess.Confirurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<Tournament>
    {
        public void Configure(EntityTypeBuilder<Tournament> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PlaceName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.TourDateTime).IsRequired();
            builder.Property(e => e.PrizFund).IsRequired();
            builder.Property(e => e.TourRating).IsRequired();

          /*  builder.HasOne(e => e.Game)
                   .WithMany(g => g.Tournaments)
                   .HasForeignKey(e => e.GameId)
                   .OnDelete(DeleteBehavior.Cascade);*/

            builder.HasMany(e => e.GameTeams)
                   .WithOne(gt => gt.Tournament)
                   .HasForeignKey(e => e.TournamentId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
