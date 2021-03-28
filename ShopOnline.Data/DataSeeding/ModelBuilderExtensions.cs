using Microsoft.EntityFrameworkCore;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.DataInit
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SYS_ROLE>().HasData(
                new SYS_ROLE()
                {
                    Id = Guid.NewGuid(),
                    Name = "admin",
                    Description = "",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                }
            );
            modelBuilder.Entity<SYS_SETTING>().HasData(
                new SYS_SETTING()
                {
                    Key = Guid.Parse("1beb61cd-b138-4117-9d61-09e46d7b4850").ToString(),
                    Value = "123",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                }
            );
        }
    }
}
