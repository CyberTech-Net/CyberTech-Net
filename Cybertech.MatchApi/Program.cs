using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MassTransit;
using CyberTech.MatchApi.Settings;
using Cybertech.MatchApi.Consumer;
using Microsoft.Extensions.DependencyInjection;
using Cybertech.MatchApi.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Cybertech.MatchApi.HostedService;
using StackExchange.Redis;

namespace CyberTech.MatchApi
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var rmqSettings = configuration.Get<AppSettings>().RmqSettings;
            var redisSettings = configuration.Get<AppSettings>().RedisSettings;

            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<ICheckMatchService, CheckMatchService>();

                    services.AddMassTransit(busConfigurator =>
                    {
                        busConfigurator.AddConsumer<CheckMatchData>();

                        busConfigurator.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(rmqSettings.Host, u =>
                            {
                                u.Username(rmqSettings.Username);
                                u.Password(rmqSettings.Password);
                            });
                            //cfg.ConfigureEndpoints(context, KebabCaseEndpointNameFormatter.Instance);
                            cfg.UseJsonSerializer();
                            cfg.ReceiveEndpoint(queueName: $"masstransit_check_match_data", endpoint =>
                            {
                                endpoint.ConfigureConsumer<CheckMatchData>(context);
                                endpoint.UseMessageRetry(r =>
                                {
                                    r.Incremental(3, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
                                });
                                endpoint.PrefetchCount = 1;
                                endpoint.UseConcurrencyLimit(1);
                            });
                        });
                    });

                    services.AddSingleton <IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisSettings.Host));

                    // Подключаем Redis.
                    services.AddSingleton<IConnectionMultiplexer>(sp =>
                            ConnectionMultiplexer.Connect(new ConfigurationOptions
                            {
                                EndPoints = { $"{redisSettings.Host}:{redisSettings.Port}" },                                 
                                AbortOnConnectFail = false,
                                AllowAdmin = true
                             }));
                    


                    // Сервис для скана Redis, который запускает CheckMatchService.
                    services.AddHostedService<GetRedisDataService>();

                });
        }
    }
}
