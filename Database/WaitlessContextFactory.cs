using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class WaitlessContextFactory : IDbContextFactory<WaitlessContext>
    {
        public WaitlessContext Create()
        {
            var environmentName =
                Environment.GetEnvironmentVariable(
                    "Hosting:Environment");

            var basePath = AppContext.BaseDirectory;

            return Create(basePath, environmentName);
        }

        public WaitlessContext Create(DbContextFactoryOptions options)
        {
            return Create(
                options.ContentRootPath,
                options.EnvironmentName);
        }

        private WaitlessContext Create(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString("PostgreSqlProvider");

            if (string.IsNullOrWhiteSpace(connstr))
            {
                throw new InvalidOperationException(
                    "Could not find a connection string named 'PostgreSqlProvider'.");
            }

            return Create(connstr);
        }

        private WaitlessContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                    $"{nameof(connectionString)} is null or empty.",
                    nameof(connectionString));

            var builder = new DbContextOptionsBuilder<WaitlessContext>();
            builder.UseNpgsql(connectionString);
            return new WaitlessContext(builder.Options);
        }
    }
}
