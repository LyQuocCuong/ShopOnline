using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data.Configurations;
using ShopOnline.Data.DataInit;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.EF
{
    public class ShopOnlineDBContext : IdentityDbContext<SYS_USER, SYS_ROLE, Guid>
    {
        public ShopOnlineDBContext(DbContextOptions options) : base(options)
        {
            //this.Database.Migrate();
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add your own configuration here - Fluent API
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new SysActionConfiguration());
            modelBuilder.ApplyConfiguration(new SysFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new SysLogActivityConfiguration());
            modelBuilder.ApplyConfiguration(new SysPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new SysSettingConfiguration());

            // 7 classes of IdentityDBContext
            modelBuilder.ApplyConfiguration(new SysUserConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new SysRoleConfiguration());
            modelBuilder.ApplyConfiguration(new SysRoleClaimConfiguration());

            ////Seeding Data
            //modelBuilder.Seed();
        }

        DbSet<CART> Carts { get; set; }
        DbSet<CATEGORY> Categories { get; set; }
        DbSet<CATEGORY_TRANSLATION> CategoryTranslations { get; set; }
        DbSet<CONTACT> Contacts { get; set; }
        DbSet<LANGUAGE> Languages { get; set; }
        DbSet<ORDER> Orders { get; set; }
        DbSet<ORDER_DETAIL> OrderDetails { get; set; }
        DbSet<PRODUCT> Products { get; set; }
        DbSet<PRODUCT_TRANSLATION> ProductTranslations { get; set; }
        DbSet<PROMOTION> Promotions { get; set; }
        DbSet<SYS_ACTION> SysActions { get; set; }
        DbSet<SYS_SETTING> SysConfigurations { get; set; }
        DbSet<SYS_FEATURE> SysFeatures { get; set; }
        DbSet<SYS_LOG_ACTIVITY> SysLogActivities { get; set; }
        DbSet<SYS_PERMISSION> SysPermissions { get; set; }
        DbSet<SYS_ROLE> SysRoles { get; set; }
        DbSet<SYS_USER> SysUsers { get; set; }
    }
}
