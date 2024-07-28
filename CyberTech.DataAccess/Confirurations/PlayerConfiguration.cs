using CyberTech.Domain.Models.Handbooks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CyberTech.DataAccess.Confirurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Players", "handbooks");

            builder.Property(e => e.NickName).IsRequired().HasMaxLength(10);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.SecondName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.BirthDate).IsRequired();

            builder.HasOne(e => e.Country)
                   .WithMany(g => g.Players)
                   .HasForeignKey(e => e.CountryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
