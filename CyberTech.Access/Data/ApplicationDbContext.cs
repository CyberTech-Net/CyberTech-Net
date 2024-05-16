using CyberTech.Core.Domain.Administration;
using CyberTech.Core.Domain.Entities;
using CyberTech.DataAccess.Confirurations;
using Microsoft.EntityFrameworkCore;

namespace CyberTech.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameTeam> GameTeams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new GameTeamConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
     
            base.OnModelCreating(modelBuilder);
        }
    }
}
