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
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    .InstallServices()
                    .ConfigureContext(configuration.GetConnectionString("DBConnection"))
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
                .AddTransient<ITournamentMeetService, TournamentMeetService>()
                .AddTransient<ITeamPlayerService, TeamPlayerService>()
                .AddTransient<ITournamentMeetTeamService, TournamentMeetTeamService>()
                .AddTransient<IRoleService, RoleService>();
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
                .AddTransient<ITournamentMeetRepository, TournamentMeetRepository>()
                .AddTransient<ITeamPlayerRepository, TeamPlayerRepository>()
                .AddTransient<ITournamentMeetTeamRepository, TournamentMeetTeamRepository>()
                .AddTransient<IRoleRepository, RoleRepository>();
            return serviceCollection;
        }
    }
}