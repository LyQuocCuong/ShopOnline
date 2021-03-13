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
            //7c0f69f6-cf0a-406d-a502-574a409266b0
            modelBuilder.Entity<SysRole>().HasData(
                new SysRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Description = "",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                }
            );
            //d68e5a88-491d-45c6-a7ea-61ff2815f8e3
            modelBuilder.Entity<SysSetting>().HasData(
                new SysSetting()
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
