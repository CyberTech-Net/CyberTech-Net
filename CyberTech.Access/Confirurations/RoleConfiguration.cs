using CyberTech.Core.Domain.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property<string>(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property<string>(x => x.Description).IsRequired().HasMaxLength(256);
        }
    }
}
