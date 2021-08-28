using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnline.WebAdmin.Services;
using ShopOnline.Models.System.User.Validator;
using ShopOnline.Models.System.User.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopOnline.Utilities.Consts;
using Microsoft.AspNetCore.Http;

namespace ShopOnline.AppAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            //Using HttpClient to call to Backend_API
            services.AddHttpClient();

            //Help to get HttpClient value in Service module
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //When calling to an Authorize Controller. It will check if the cookie is valid
            //If don't then redirect to LoginPath and the currentURL become ReturnUrl param in LoginPath
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Login/Index";
                        options.Cookie.Name = "CuongCookie";
                        options.Cookie.HttpOnly = true;
                        options.Cookie.IsEssential = true;
                    });

            services.AddControllersWithViews();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(SystemValue.TIMELIFE_SESSION_MINUTES);
                options.Cookie.Name = "CuongSessionCookie";
            });

            //DI for Fluent Validation
            services.AddTransient<IValidator<LoginInfoDto>, LoginUserValidator>();
            services.AddTransient<IValidator<CreateUserDto>, CreateUserValidator>();

            //DI
            services.AddTransient<IUserService, UserService>();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                    //Using for Mapping id for Get/Post request (update, delete)
            });
        }
    }
}
