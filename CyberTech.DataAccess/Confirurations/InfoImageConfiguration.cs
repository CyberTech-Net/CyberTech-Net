using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CyberTech.DataAccess.Confirurations
{
    public class InfoImageConfiguration : IEntityTypeConfiguration<InfoImageEntity>
    {
        public void Configure(EntityTypeBuilder<InfoImageEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(e => e.Info)
                   .WithMany(g => g.InfoImages)
                   .HasForeignKey(e => e.InfoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
