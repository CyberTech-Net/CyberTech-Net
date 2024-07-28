using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(e => e.Login);

            builder.ToTable("Users", "handbooks");

            builder.Property(e=>e.Login).HasMaxLength(20);
            builder.Property(e=>e.Password).IsRequired().HasMaxLength(20);
            builder.Property(e=>e.Email).IsRequired().HasMaxLength(20);            

            builder.HasOne(e => e.Role)
                   .WithMany(g=>g.Users)
                   .HasForeignKey(e => e.RoleId)
                   .IsRequired();
        }
    }
}
