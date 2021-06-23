using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ShopOnline.Data.EF;
using ShopOnline.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Repositories.Definition
{
    public class ShopOnlineRepository : IDisposable
    {
        public readonly ShopOnlineDBContext DBContext;
        public readonly IConfiguration Configuration;
        public readonly UserManager<S_USER> API_UserManager;
        public readonly SignInManager<S_USER> API_SignInManager;

        public ShopOnlineRepository(ShopOnlineDBContext dbContext,
                                    IConfiguration configuration,
                                    UserManager<S_USER> api_UserManager,
                                    SignInManager<S_USER> api_SignInManager)
        {
            DBContext = dbContext;
            Configuration = configuration;
            API_UserManager = api_UserManager;
            API_SignInManager = api_SignInManager;
        }

        public bool SaveChanges()
        {
            try
            {
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #region PRODUCT
        private ProductRepository productRepository { get; set; }
        public ProductRepository PRODUCT_REPOSITORY
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(this);
                return productRepository;
            }
        }
        #endregion

        #region S_USER
        private UserRepository suserRepository { get; set; }
        public UserRepository SUSER_REPOSITORY
        {
            get
            {
                if (suserRepository == null)
                    suserRepository = new UserRepository(this);
                return suserRepository;
            }
        }
        #endregion

    }
}
