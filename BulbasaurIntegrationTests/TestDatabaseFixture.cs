using BulbasaurAPI.Database;
using dotenv.net;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        private IConfigurationRoot _configuration;
        private static readonly object _lock = new object();
        private static bool _databaseInitialized = false;

        public TestDatabaseFixture()
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder();
            _configuration = configBuilder.AddJsonFile("appsettings.Test.json").Build();

            // Set your own connection string for testing here
            Connection = new SqlConnection(_configuration.GetConnectionString("_connString"));

            Seed();

            Connection.Open();
        }

        // Get a new db context for the given test server
        public DbServerContext CreateContext(DbTransaction? transaction = null)
        {
            var builder = new DbContextOptionsBuilder<DbServerContext>().UseSqlServer(Connection);
            var context = new DbServerContext(builder.Options);
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