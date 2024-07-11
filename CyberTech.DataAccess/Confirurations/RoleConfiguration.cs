using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property<string>(x => x.TitleRole).IsRequired().HasMaxLength(50);
            builder.Property<string>(x => x.Description).HasMaxLength(500);
        }
    }
}
