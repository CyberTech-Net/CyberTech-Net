using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CyberTech.DataAccess.Confirurations
{
    public class TournamentMeetConfiguration : IEntityTypeConfiguration<TournamentMeetEntity>
    {
        public void Configure(EntityTypeBuilder<TournamentMeetEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.DataTournamentMeet).IsRequired();

            builder.HasOne(e => e.Tournament)
                   .WithMany(g=>g.TournamentMeets)
                   .HasForeignKey(e => e.TournamentId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
