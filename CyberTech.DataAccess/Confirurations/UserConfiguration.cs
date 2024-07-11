using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(e => e.Login);
            builder.Property<string>(e=>e.Login).HasMaxLength(20);
            builder.Property<string>(e=>e.Password).IsRequired().HasMaxLength(20);
            builder.Property<string>(e=>e.Email).IsRequired().HasMaxLength(20);            
            builder.HasOne(e => e.Role)
                   .WithMany(g=>g.Users)
                   .HasForeignKey(e => e.RoleId)
                   .IsRequired();
        }
    }
}
