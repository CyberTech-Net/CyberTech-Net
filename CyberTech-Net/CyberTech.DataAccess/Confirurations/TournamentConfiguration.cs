using CyberTech.Domain.Models.Tournaments;
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

            builder.ToTable("Tournaments", "tournaments");

            builder.Property<string>(e => e.TitleTournament).IsRequired().HasMaxLength(150);
            builder.Property<string>(e => e.TypeTournament).IsRequired().HasMaxLength(20);
            builder.Property(e => e.DateTournamentInit).IsRequired().HasColumnType("date");            
            builder.Property(e => e.DateTournamentEnd).IsRequired().HasColumnType("date");
            builder.Property(e => e.PlaceName).IsRequired().HasMaxLength(150);
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
