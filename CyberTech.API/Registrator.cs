using CyberTech.API.HostedServices;
using CyberTech.API.Settings;
using CyberTech.Application.Services;
using CyberTech.Core.IRepositories;
using CyberTech.Core.IServices;
using CyberTech.DataAccess;
using CyberTech.DataAccess.Repositories;
using CyberTech.Settings.RabbitMqQueueSettings;
using RabbitMQ.Client;

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
                .InstallOptions(configuration)
                .ConfigureContext(connectionSettings.DBConnection)
                .InstallRabbitMq(connectionSettings.Rmq)
                .InstallServices()
                .InstallRepositories();
            return services;
        }

        private static IServiceCollection InstallOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                .Configure<MatchPlanned>(configuration.GetSection(MatchPlanned.Section))
                .Configure<MatchEnded>(configuration.GetSection(MatchEnded.Section));
            return serviceCollection;
        }

        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<IRabbitMqService, RabbitMqService>()
                .AddTransient<ICountryService, CountryService>()
                .AddTransient<IGameTypeService, GameTypeService>()
                .AddTransient<IInfoService, InfoService>()
                .AddTransient<ITeamService, TeamService>()
                .AddTransient<IPlayerService, PlayerService>()
                .AddTransient<ITournamentService, TournamentService>()
                .AddTransient<IMatchesService, MatchesService>()
                .AddTransient<ITeamPlayerService, TeamPlayerService>()
                .AddTransient<IMatchResultsService, MatchResultsService>()
                .AddTransient<IRoleService, RoleService>()
                .AddHostedService<MeetFinishedHandlerService>();
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
                .AddTransient<ITournamentMeetRepository, MatchRepository>()
                .AddTransient<ITeamPlayerRepository, TeamPlayerRepository>()
                .AddTransient<IMatchResultRepository, MatchResultRepository>()
                .AddTransient<IRoleRepository, RoleRepository>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRabbitMq(this IServiceCollection serviceCollection, RmqOptions settings)
        {
            var factory = new ConnectionFactory()
            {
                HostName = settings.Host,
                VirtualHost = settings.VHost,
                UserName = settings.Login,
                Password = settings.Password,
            };

            serviceCollection.AddSingleton(provider =>
            {
                return factory.CreateConnection();
            });

            return serviceCollection;
        }
    }
}