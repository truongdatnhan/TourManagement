using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Persistence
{
    public class QLTVFactory : IDesignTimeDbContextFactory<QLTVContext>
    {
        public QLTVContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuration.GetConnectionString("ThuVienDB");
            var optionsBuilder = new DbContextOptionsBuilder<QLTVContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new QLTVContext(optionsBuilder.Options);
        }
    }
}