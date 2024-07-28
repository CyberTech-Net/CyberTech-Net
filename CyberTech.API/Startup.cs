﻿using AutoMapper;
using CyberTech.API.Mapping;
using CyberTech.API.Settings;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace CyberTech.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ConnectionOptions ConnectionSettings { get; init; } = new ConnectionOptions();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.GetSection(ConnectionOptions.Section).Bind(ConnectionSettings);
            Configuration.GetSection($"{ConnectionOptions.Section}:{RmqOptions.Section}").Bind(ConnectionSettings.Rmq);
        }

        private static IServiceCollection InstallAutomapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CountryMappingsProfile>();
                cfg.AddProfile<GameTypeMappingsProfile>();
                cfg.AddProfile<TeamMappingsProfile>();
                cfg.AddProfile<PlayerMappingsProfile>();
                cfg.AddProfile<TournamentMappingsProfile>();
                cfg.AddProfile<TeamPlayerMappingsProfile>();
                cfg.AddProfile<RoleMappingsProfile>();
                cfg.AddProfile<Core.Mapping.CountryMappingsProfile>();
                cfg.AddProfile<Core.Mapping.GameTypeMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TeamMappingsProfile>();
                cfg.AddProfile<Core.Mapping.PlayerMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TournamentMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TeamPlayerMappingsProfile>();
                cfg.AddProfile<Core.Mapping.RoleMappingsProfile>();
            });            
            configuration.AssertConfigurationIsValid();
            return configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            InstallAutomapper(services);

            services.AddServices(ConnectionSettings, Configuration);
            services.AddControllers();

            services.AddControllers().AddMvcOptions(x => x.SuppressAsyncSuffixInActionNames = false);                     

            services.AddSwaggerGen(options  =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CyberTechNet.Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);

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
                    ValidAudience = audience,
                    ValidateAudience = true
                };
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // for testing

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CyberTechNet.Api"));


            app.UseHttpsRedirection();
           

            app.UseStaticFiles();
            app.UseCors();

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
