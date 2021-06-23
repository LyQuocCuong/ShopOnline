using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopOnline.Data.EF;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Service.Public.IServices;
using ShopOnline.Service.Services;
using ShopOnline.Services.IServices;
using ShopOnline.Services.Services;

namespace ShopOnline.BackendApi
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
            //MVC
            services.AddControllers();
            #region SWAGGER
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            #endregion
            //DI for DbContext
            services.AddDbContext<ShopOnlineDBContext>(
                options => options.UseSqlServer("name=ConnectionStrings:ShopOnlineDB"));
            //Configurate using the lib Identity
            services.AddIdentity<S_USER, S_ROLE>()
                .AddEntityFrameworkStores<ShopOnlineDBContext>()
                .AddDefaultTokenProviders();
            //DI for lib Identity
            services.AddTransient<UserManager<S_USER>, UserManager<S_USER>>();
            services.AddTransient<SignInManager<S_USER>, SignInManager<S_USER>>();
            //DI
            services.AddTransient<ShopOnlineRepository, ShopOnlineRepository>();
            services.AddTransient<IPublicProductService, PublicProductService>();
            services.AddTransient<IUserPublicService, UserPublicService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            #region third party - Serilog
            //Add Provider
            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
            #endregion

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

            #region SWAGGER
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            #endregion


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
