using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = ExtractConnectionString();

            var databaseProvider = ExtractProvider();

            ConfigureOptionBuilderDBProvider(databaseProvider, optionsBuilder, connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }

        public static DbContextOptions<AppDbContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = ExtractConnectionString();

            var databaseProvider = ExtractProvider();

            ConfigureOptionBuilderDBProvider(databaseProvider, optionsBuilder, connectionString);

            return optionsBuilder.Options;
        }

        public static DbContextOptions<AppDbContext> GetTestableOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseInMemoryDatabase("test-database");

            return optionsBuilder.Options;
        }

        public static void ConfigureOptionsBuilder(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ExtractConnectionString();

            var databaseProvider = ExtractProvider();

            ConfigureOptionBuilderDBProvider(databaseProvider, optionsBuilder, connectionString);
        }

        private static void ConfigureOptionBuilderDBProvider(string databaseProvider, DbContextOptionsBuilder optionsBuilder,
            string connectionString)
        {
            if (databaseProvider == "Postgres")
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
            else
            {
                throw new Exception("Unknown provider");
            }
        }

        private static string ExtractConnectionString()
        {
            var connectionString = Environment.GetEnvironmentVariable("DB_PATH");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Missing connection string");
            }

            return connectionString;
        }

        private static string ExtractProvider()
        {
            var databaseProvider = Environment.GetEnvironmentVariable("DB_PROVIDER");

            if (string.IsNullOrEmpty(databaseProvider))
            {
                throw new Exception("Missing database provider");
            }

            return databaseProvider;
        }
    }
}
