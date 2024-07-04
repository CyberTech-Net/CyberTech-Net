using CyberTech.Storage.Api.Dto;
using CyberTech.Storage.Api.Services;
using CyberTech.Storage.Core.Abstractions.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;

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


            services.AddSingleton<IFileService, FileService>();
       //     services.AddSingleton<IChatService, ChatService>();

            services.AddControllers()
                .AddJsonOptions(options =>
                options.JsonSerializerOptions.PropertyNamingPolicy = null);

            // Register the Swagger generator
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
