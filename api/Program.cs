using BulbasaurAPI.ExternalAPIs;
using BulbasaurAPI.Middlewares;
using BulbasaurAPI.Models;
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

            builder.Services.AddCors(p =>
            {
                p.AddPolicy("policyCors", b =>
                {
                    b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

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
            builder.Services.AddScoped<IChildrenRepository, ChildrenRepository>();
            builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
            builder.Services.AddScoped<IBaseRepository<Role>, RoleRepository>();

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
            app.UseCors("policyCors");
            app.UseHttpsRedirection();

            // Logging middleware
            //app.Use(async (context, next) =>
            //{
            //    var loggingMiddleware = new LoggingMiddleware(new DbServerContext(builder.Configuration));
            //    await loggingMiddleware.InvokeAsync(context, next);
            //});

            // Add custom authentication and authorization middlewares here     UNCOMMENT THIS PART ONCE LOGIN IS IMPLEMENTED
            //app.UseMiddleware<AuthenticationMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}