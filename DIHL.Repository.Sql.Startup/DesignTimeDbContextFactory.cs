using System;
using System.IO;
using DIHL.Repository.Sql.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DIHL.Repository.Sql.Startup
{
    /// <summary>
    /// Responsible for constructing the Db Context with the connection string from the appsettings file.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DihlDbContext>
    {
        public DihlDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DihlDbContext>();

            var connectionString = configuration.GetConnectionString("DIHLDbConnection");

            builder.UseSqlServer(connectionString);

            return new DihlDbContext(builder.Options);
        }
    }
}
