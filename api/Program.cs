using BulbasaurAPI.ExternalAPIs;
using BulbasaurAPI.Middlewares;
using BulbasaurAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;

namespace BulbasaurAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adding DbContext to Services
            builder.Services.AddDbContext<DbServerContext>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Add custom authentication and authorization middlewares here
            app.Use(async (context, next) =>
                {
                    AuthenticationMiddleware tokenMiddleware = new(next);
                    await tokenMiddleware.InvokeAsync(context);
                }
            );

            app.MapControllers();

            app.Run();
        }
    }
}