using BulbasaurAPI;
using dotenv.net;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbasaurIntegrationTests
{
    public class TestDatabaseFixture : IDisposable
    {
        public DbConnection Connection { get; }

        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            var connString = "server=localhost;database=bulbaTestDB;Integrated Security=true;encrypt=false;";
            Connection = new SqlConnection(connString);

            Seed();

            Connection.Open();
        }

        // Get a new db context for the given test server
        public DbServerContext CreateContext(DbTransaction? transaction = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbServerContext>().UseSqlServer(Connection.ConnectionString);
            var context = new DbServerContext(optionsBuilder.Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }
            return context;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (_databaseInitialized) return;

                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    DatabaseUtil.SeedData(context);
                }
                _databaseInitialized = true;
            }
        }

        public void Dispose() => Connection.Dispose();
    }
}