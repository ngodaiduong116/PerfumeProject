using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace ePerfume.Data.EF
{
    public class EPerfumeContextFactory : IDesignTimeDbContextFactory<EPerfumeDbContext>
    {
        public EPerfumeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ePerfumeDb");

            var optionsBuilder = new DbContextOptionsBuilder<EPerfumeDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new EPerfumeDbContext(optionsBuilder.Options);
        }
    }
}
