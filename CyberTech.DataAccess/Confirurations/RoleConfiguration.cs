using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Roles", "handbooks");

            builder.Property<string>(x => x.TitleRole).IsRequired().HasMaxLength(50);
            builder.Property<string>(x => x.Description).HasMaxLength(500);
        }
    }
}
