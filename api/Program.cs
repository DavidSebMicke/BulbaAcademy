using BulbasaurAPI.ExternalAPIs;
using BulbasaurAPI.Middlewares;
using BulbasaurAPI.Repository;
using BulbasaurAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace BulbasaurAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddTransient<Seed>();

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DbServerContext>();
            builder.Services.AddScoped<ICaregiverRepository, CaregiverRepository>();
            builder.Services.AddScoped<IPersonRepository, PersonRepository>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();


            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
                SeedData(app);

            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                
                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<Seed>(); 
                    service.SeedDataContext();
                }
            }

            app.UseHttpsRedirection();

            // Add custom authentication and authorization middlewares here     UNCOMMENT THIS PART ONCE LOGIN IS IMPLEMENTED
            //app.UseMiddleware<AuthenticationMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}