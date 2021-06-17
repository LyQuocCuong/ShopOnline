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
            modelBuilder.Entity<S_ROLE>().HasData(
                new S_ROLE()
                {
                    Id = Guid.NewGuid(),
                    Name = "admin",
                    DESCRIPTION = "",
                    CREATED_DATE = DateTime.Now,
                    IS_DELETED = false,
                }
            );
            modelBuilder.Entity<S_SETTING>().HasData(
                new S_SETTING()
                {
                    KEY = Guid.Parse("1beb61cd-b138-4117-9d61-09e46d7b4850").ToString(),
                    VALUE = "123",
                    CREATED_DATE = DateTime.Now,
                    IS_DELETED = false
                }
            );
        }
    }
}
