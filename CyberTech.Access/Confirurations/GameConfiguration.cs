using CyberTech.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property<string>(e=>e.Name).IsRequired().HasMaxLength(50);
            builder.Property<string>(e=>e.Description).IsRequired().HasMaxLength(256);

            builder.HasMany(g => g.GameTeams)
                .WithOne(e => e.Game)
                .HasForeignKey(e => e.GameId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
    
}
