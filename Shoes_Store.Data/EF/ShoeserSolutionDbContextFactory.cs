using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shoes_Store.Data.EF
{
    class ShoeserSolutionDbContextFactory : IDesignTimeDbContextFactory<ShoeserDbContext>
    {
        public ShoeserDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("ShoeserSolutionDb");
            var optionsBuilder = new DbContextOptionsBuilder<ShoeserDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ShoeserDbContext(optionsBuilder.Options);
        }
    }
}
