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

            ConfigureOptionBuilder(databaseProvider, optionsBuilder, connectionString);


            return new AppDbContext(optionsBuilder.Options);
        }

        public static DbContextOptions<AppDbContext> GetOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = ExtractConnectionString();

            var databaseProvider = ExtractProvider();

            ConfigureOptionBuilder(databaseProvider, optionsBuilder, connectionString);

            optionsBuilder.UseNpgsql(connectionString);

            return optionsBuilder.Options;
        }

        private static void ConfigureOptionBuilder(string databaseProvider, DbContextOptionsBuilder<AppDbContext> optionsBuilder,
            string connectionString)
        {
            if (databaseProvider == "Postgres")
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
            else if (databaseProvider == "Mssql")
            {
                optionsBuilder.UseSqlServer(connectionString);
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
