using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class GameTypeConfiguration : IEntityTypeConfiguration<GameTypeEntity>
    {
        public void Configure(EntityTypeBuilder<GameTypeEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property<string>(e=>e.TitleGame).IsRequired().HasMaxLength(50);
            builder.Property<string>(e=>e.Description).IsRequired().HasMaxLength(500);
            
    }
    }
    
}
