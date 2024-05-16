using CyberTech.Core.Domain.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(e => e.Id);

            builder.Property<string>(e=>e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property<string>(e=>e.LastName).IsRequired().HasMaxLength(50);
            builder.Property<string>(e=>e.Email).IsRequired().HasMaxLength(50);
            builder.Property<string>(e=>e.Country).IsRequired().HasMaxLength(50);


            builder.HasOne(e => e.Role)
                   .WithOne()
                   .HasForeignKey<Role>(e => e.UserId)
                   .IsRequired();
        }
    }
}
