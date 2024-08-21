using CyberTech.DataAccess.Confirurations;
using CyberTech.Domain.Models.Handbooks;
using CyberTech.Domain.Models.Tournaments;
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
        public DbSet<GameTypeEntity> GameTypes { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<TournamentEntity> Tournaments { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamPlayerEntity> TeamPlayers { get; set; }
        public DbSet<MatchEntity> Matchs { get; set; }
        public DbSet<MatchResultEntity> MatchResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new GameConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TeamPlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TournamentConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());
            modelBuilder.ApplyConfiguration(new MatchResultConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
