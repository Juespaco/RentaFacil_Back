using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework
{
    public class PersistenceContextFactory : IDesignTimeDbContextFactory<PersistenceContext>
    {
        public PersistenceContext CreateDbContext(string[] args)
        {

            var basePath = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json") // usa el archivo que contiene tu cadena de conexión
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<PersistenceContext>();
            var connectionString = configuration.GetConnectionString("Base");

            optionsBuilder.UseSqlServer(connectionString); // o el proveedor que uses

            return new PersistenceContext(optionsBuilder.Options, configuration);
        }
    }
}
