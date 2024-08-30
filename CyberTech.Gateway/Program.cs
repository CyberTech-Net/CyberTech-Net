using CyberTech.Gateway.Extensions;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace CyberTech.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddAppAuthetication();

            // Load the appropriate Ocelot configuration file
            if (builder.Environment.EnvironmentName.ToString().ToLower().Equals("production"))
            {
                builder.Configuration.AddJsonFile("ocelot.Production.json", optional: false, reloadOnChange: true);
            }
            else
            {
                builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
            }

            // Add Ocelot services
            builder.Services.AddOcelot(builder.Configuration);

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials();
                    });
            });

            var app = builder.Build();
        
        
            app.UseCors("AllowReactApp");
            app.UseWebSockets();

            app.MapGet("/", () => "Hello World!");

            // Use Ocelot middleware
            app.UseOcelot().Wait();

            app.Run();
        }
    }
}