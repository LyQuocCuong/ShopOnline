﻿using Microsoft.AspNetCore.Identity;
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
    public class ShopOnlineDBContext : IdentityDbContext<S_USER, S_ROLE, Guid>
    {
        public ShopOnlineDBContext(DbContextOptions options) : base(options)
        {
            //this.Database.Migrate();
            //this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //add your own configuration here - Fluent API
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
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());

            //Our system classes
            modelBuilder.ApplyConfiguration(new SysActionConfiguration());
            modelBuilder.ApplyConfiguration(new SysFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new SysLogActivityConfiguration());
            modelBuilder.ApplyConfiguration(new SysPermissionConfiguration());
            modelBuilder.ApplyConfiguration(new SysSettingConfiguration());

            //7 default classes of IdentityDBContext
            modelBuilder.ApplyConfiguration(new SysUserClaimConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserLoginConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new SysUserTokenConfiguration());
            modelBuilder.ApplyConfiguration(new SysRoleClaimConfiguration());
            //Customized Structure of IdentityDBContext
            modelBuilder.ApplyConfiguration(new SysUserConfiguration());
            modelBuilder.ApplyConfiguration(new SysRoleConfiguration());

            ////Seeding Data
            //modelBuilder.Seed();
        }

        DbSet<CART> CART { get; set; }
        DbSet<CATEGORY> CATEGORY { get; set; }
        DbSet<CATEGORY_TRANSLATION> CATEGORY_TRANSLATION { get; set; }
        DbSet<CONTACT> CONTACT { get; set; }
        DbSet<LANGUAGE> LANGUAGE { get; set; }
        DbSet<ORDER> ORDER { get; set; }
        DbSet<ORDER_DETAIL> ORDER_DETAIL { get; set; }
        DbSet<PRODUCT> PRODUCT { get; set; }
        DbSet<PRODUCT_IN_CATEGORY> PRODUCT_IN_CATEGORY { get; set; }
        DbSet<PRODUCT_TRANSLATION> PRODUCT_TRANSLATION { get; set; }
        DbSet<PROMOTION> PROMOTION { get; set; }
        DbSet<PRODUCT_IMAGE> PRODUCT_IMAGE { get; set; }

        //Our System Configurations
        DbSet<S_ACTION> S_ACTION { get; set; }
        DbSet<S_FEATURE> S_FEATURE { get; set; }
        DbSet<S_LOG_ACTIVITY> S_LOG_ACTIVITY { get; set; }
        DbSet<S_PERMISSION> S_PERMISSION { get; set; }
        DbSet<S_SETTING> S_SETTING { get; set; }

        //Customized structure classes of IdentityDBContext
        DbSet<S_USER> S_USER { get; set; }
        DbSet<S_ROLE> S_ROLE { get; set; }

    }
}
