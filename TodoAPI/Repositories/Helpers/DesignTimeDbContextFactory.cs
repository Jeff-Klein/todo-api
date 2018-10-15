using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TodoAPI.Repositories.Helpers
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TodoContext>
    {
        public TodoContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TodoContext>();
            var connectionString = configuration.GetConnectionString("tododb");
            builder.UseSqlServer(connectionString);
            return new TodoContext(builder.Options);
        }
    }
}
