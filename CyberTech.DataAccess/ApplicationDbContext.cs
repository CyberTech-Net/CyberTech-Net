using CyberTech.DataAccess.Confirurations;
using CyberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CyberTech.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<InfoEntity> InfoList { get; set; }
        public DbSet<InfoImageEntity> InfoImageList { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GameTypeEntity> GameTypes { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<TournamentEntity> Tournaments { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamPlayerEntity> TeamPlayers { get; set; }
        public DbSet<TournamentMeetEntity> TournamentMeets { get; set; }
        public DbSet<TournamentMeetTeamEntity> TournamentMeetTeams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new GameTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InfoConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamPlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentMeetConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentMeetTeamConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
