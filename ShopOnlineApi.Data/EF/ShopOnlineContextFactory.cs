using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.EF
{
    public class ShopOnlineContextFactory : IDesignTimeDbContextFactory<ShopOnlineDBContext>
    {
        public ShopOnlineDBContext CreateDbContext(string[] args)
        {
            //Install 2 packages for this statement
            //Microsoft.Extensions.Configuration.FileExtensions
            //Microsoft.Extensions.Configuration.Json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionStrings = configuration.GetConnectionString("ShopOnlineDB");

            var optionsBuilder = new DbContextOptionsBuilder<ShopOnlineDBContext>();
            optionsBuilder.UseSqlServer(connectionStrings);

            return new ShopOnlineDBContext(optionsBuilder.Options);
        }
    }
}
