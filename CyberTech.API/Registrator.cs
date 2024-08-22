using CyberTech.API.Settings;
using CyberTech.Application.Services;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.DataAccess;
using CyberTech.DataAccess.Repositories;

namespace CyberTech.API
{
    /// <summary>
    /// Регистратор сервиса.
    /// </summary>
    public static class Registrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services, ConnectionOptions connectionSettings, IConfiguration configuration)
        {
            services
                    .InstallServices()
                    .ConfigureContext(connectionSettings.DBConnection)
                    .InstallRepositories();
            return services;
        }

        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection                
                .AddTransient<ICountryService, CountryService>()
                .AddTransient<IGameTypeService, GameTypeService>()
                .AddTransient<IInfoService, InfoService>()
                .AddTransient<ITeamService, TeamService>()
                .AddTransient<IPlayerService, PlayerService>()
                .AddTransient<ITournamentService, TournamentService>()
                .AddTransient<IMatchService, MatchService>()
                .AddTransient<ITeamPlayerService, TeamPlayerService>()
                .AddTransient<IMatchResultService, MatchResultsService>()
                .AddTransient<IGenMatchResultService, GenMatchResultService>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddTransient<IGameTypeRepository, GameTypeRepository>()
                .AddTransient<ITeamRepository, TeamRepository>()
                .AddTransient<IInfoRepository, InfoRepository>()
                .AddTransient<IPlayerRepository, PlayerRepository>()
                .AddTransient<ITournamentRepository, TournamentRepository>()
                .AddTransient<IMatchRepository, MatchRepository>()
                .AddTransient<ITeamPlayerRepository, TeamPlayerRepository>()
                .AddTransient<IMatchResultRepository, MatchResultRepository>();
            return serviceCollection;
        }      
    }
}