using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BulbasaurAPI.Database
{
    public class ContextFactory : IDisposable
    {
        private DbConnection Connection { get; set; }

        // Creates a context from scratch
        public DbServerContext CreateContext()
        {
            var configBuilder = new ConfigurationBuilder();
            var config = configBuilder.AddJsonFile("appsettings.json").Build();

            Connection = new SqlConnection(config.GetConnectionString("_connString"));
            Connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<DbServerContext>().UseSqlServer(Connection);

            return new DbServerContext(optionsBuilder.Options);
        }

        public void Dispose() => Connection.Dispose();
    }
}