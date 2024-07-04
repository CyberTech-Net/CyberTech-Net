using AutoMapper;
using CyberTech.API.Mapping;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

namespace CyberTech.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
                cfg.AddProfile<InfoMappingsProfile>();
                cfg.AddProfile<TeamMappingsProfile>();
                cfg.AddProfile<PlayerMappingsProfile>();
                cfg.AddProfile<TournamentMappingsProfile>();
                cfg.AddProfile<TournamentMeetMappingsProfile>();
                cfg.AddProfile<TeamPlayerMappingsProfile>();
                cfg.AddProfile<TournamentMeetTeamMappingsProfile>();
                cfg.AddProfile<RoleMappingsProfile>();
                cfg.AddProfile<Core.Mapping.CountryMappingsProfile>();
                cfg.AddProfile<Core.Mapping.GameTypeMappingsProfile>();
                cfg.AddProfile<Core.Mapping.InfoMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TeamMappingsProfile>();
                cfg.AddProfile<Core.Mapping.PlayerMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TournamentMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TournamentMeetMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TeamPlayerMappingsProfile>();
                cfg.AddProfile<Core.Mapping.TournamentMeetTeamMappingsProfile>();
                cfg.AddProfile<Core.Mapping.RoleMappingsProfile>();
            });            
            configuration.AssertConfigurationIsValid();
            return configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            InstallAutomapper(services);

            services.AddServices(Configuration);
            services.AddControllers();

            services.AddControllers().AddMvcOptions(x =>
                x.SuppressAsyncSuffixInActionNames = false);                     

            services.AddControllersWithViews().AddJsonOptions(x =>
                  x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CyberTechNet.Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowReactLocalhost",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                        });
            });
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CyberTechNet.Api"));
            }
            
            app.UseHttpsRedirection();
            app.UseCors("AllowReactLocalhost");

            app.UseStaticFiles();
            app.UseCors();

            app.UseRouting();
            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
