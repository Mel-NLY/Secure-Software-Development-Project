using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using SSDAssignmentBOX.Models;
using System.IO;

namespace SSDAssignmentBOX
{
    public class SSDAssignmentBOXContextFactory : IDesignTimeDbContextFactory<BookContext>
    {
        public BookContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BookContext> ();

            var connectionString = configuration.GetConnectionString("BookContext");

            builder.UseSqlServer(connectionString);

            return new BookContext(builder.Options);
        }
    }
}
