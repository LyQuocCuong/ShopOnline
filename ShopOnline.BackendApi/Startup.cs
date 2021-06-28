using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ShopOnline.BackendApi.Extensions;
using ShopOnline.Data.EF;
using ShopOnline.Data.Entities;
using ShopOnline.Data.Repositories.Definition;
using ShopOnline.Service.Public.IServices;
using ShopOnline.Service.Services;
using ShopOnline.Services.IServices;
using ShopOnline.Services.Services;
using System.Text;

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
            //Model
            services.AddControllers();

            //SWAGGER
            services.AddSwaggerExtension();

            //DI for DbContext
            services.AddDbContext<ShopOnlineDBContext>(
                options => options.UseSqlServer("name=ConnectionStrings:ShopOnlineDB"));

            //Configurate using the lib Identity
            services.AddIdentity<S_USER, S_ROLE>()
                .AddEntityFrameworkStores<ShopOnlineDBContext>()
                .AddDefaultTokenProviders();

            //DI for API Identity
            services.AddTransient<UserManager<S_USER>, UserManager<S_USER>>();
            services.AddTransient<SignInManager<S_USER>, SignInManager<S_USER>>();

            //DI
            services.AddTransient<ShopOnlineRepository, ShopOnlineRepository>();
            services.AddTransient<IPublicProductService, PublicProductService>();
            services.AddTransient<IUserPublicService, UserPublicService>();

            //Validate JWT
            string issuer = Configuration["Token:Issuer"];
            string secrectKey = Configuration["Token:Secrect_Key"];
            byte[] signingKeyBytes = Encoding.UTF8.GetBytes(secrectKey);
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });

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

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            //SWAGGER
            app.UseSwaggerExtension();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
