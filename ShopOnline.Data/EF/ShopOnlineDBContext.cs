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
    public class ShopOnlineDBContext : IdentityDbContext<SysUser, SysRole, Guid>
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

        DbSet<Cart> Carts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductTranslation> ProductTranslations { get; set; }
        DbSet<Promotion> Promotions { get; set; }
        DbSet<SysAction> SysActions { get; set; }
        DbSet<SysSetting> SysConfigurations { get; set; }
        DbSet<SysFeature> SysFeatures { get; set; }
        DbSet<SysLogActivity> SysLogActivities { get; set; }
        DbSet<SysPermission> SysPermissions { get; set; }
        DbSet<SysRole> SysRoles { get; set; }
        DbSet<SysUser> SysUsers { get; set; }
    }
}
