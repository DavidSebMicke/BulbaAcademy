using BulbasaurAPI.ExternalAPIs;

namespace BulbasaurAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TEST();
            Console.ReadKey();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        private static async void TEST()
        {
            await EmailAPI.Send2FAEmail("emil.walin@gmail.com");
        }
    }
}