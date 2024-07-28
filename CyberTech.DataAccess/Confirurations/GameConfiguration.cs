using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("GameTypes", "handbooks");

            builder.Property(e => e.TitleGame).IsRequired().HasMaxLength(50);
            builder.Property(e=>e.Description).IsRequired().HasMaxLength(500);
            builder.Property(e=>e.Category).IsRequired().HasMaxLength(50);  
            builder.Property(e=>e.ImageId).IsRequired().HasMaxLength(50);
            
        }
    }
    
}
