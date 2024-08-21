using Amazon.Util.Internal.PlatformServices;
using CyberTech.Storage.Api.Consumers;
using CyberTech.Storage.Api.Services;
using CyberTech.Storage.Api.Settings;
using CyberTech.Storage.Core.Abstractions.Repositories;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;
using System.Text;

namespace CyberTech.Storage.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
           Configuration = configuration;            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();

            services.Configure<DataStorageSettings>(Configuration.GetSection(nameof(DataStorageSettings)));

            services.AddSingleton<IDataStorageSettings>(provider =>
               provider.GetRequiredService<IOptions<DataStorageSettings>>().Value);

            var rmqSettings = Configuration.Get<AppSettings>().RmqSettings;

            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<DelRecConsume>();

                busConfigurator.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rmqSettings.Host, u =>
                    {
                        u.Username(rmqSettings.Username);
                        u.Password(rmqSettings.Password);
                    });
                    cfg.ConfigureEndpoints(context, KebabCaseEndpointNameFormatter.Instance);
                    cfg.UseJsonSerializer();
                    cfg.ReceiveEndpoint(queueName: $"event_queue_delete_mongo_record", endpoint =>
                    {
                        endpoint.ConfigureConsumer<DelRecConsume>(context);
                    });
                });
            });

            services.AddSingleton<IFileService, FileService>();

            services.AddControllers()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference= new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id=JwtBearerDefaults.AuthenticationScheme
                            }
                        }, new string[]{}
                    }
                });
            });

            this.ConfigureAuthentication(services);
            services.AddAuthorization();
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var settingsSection = Configuration.GetSection("ApiSettings");
            var secret = settingsSection.GetValue<string>("Secret");
            var issuer = settingsSection.GetValue<string>("Issuer");
            var audience = settingsSection.GetValue<string>("Audience");
            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable middleware to serve generated Swagger as a JSON endpoint
                app.UseSwagger();
                // Enable Swagger UI
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Storage");
                });
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
