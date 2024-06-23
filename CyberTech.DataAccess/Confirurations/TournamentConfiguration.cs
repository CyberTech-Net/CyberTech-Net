using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CyberTech.DataAccess.Confirurations
{
    public class TournamentConfiguration : IEntityTypeConfiguration<TournamentEntity>
    {
        public void Configure(EntityTypeBuilder<TournamentEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property<string>(e => e.TitleTournament).IsRequired().HasMaxLength(150);
            builder.Property<string>(e => e.TypeTournament).IsRequired().HasMaxLength(20);
            builder.Property(e => e.DataTournamentInit).IsRequired();
            builder.Property(e => e.DataTournamentEnd).IsRequired();
            builder.Property<string>(e => e.PlaceName).IsRequired().HasMaxLength(150);
            builder.Property(e => e.EarndTournament).IsRequired();     
            builder.Property<decimal>(e => e.EarndTournament).HasPrecision(10, 2);
            builder.Property<decimal>(x => x.EarndTournament).HasDefaultValue(0.0);

            builder.HasOne(e => e.GameType)
                   .WithMany(g=>g.Tournaments)
                   .HasForeignKey(e => e.GameTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
