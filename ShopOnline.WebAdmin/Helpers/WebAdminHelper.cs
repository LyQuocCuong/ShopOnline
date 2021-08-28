using Microsoft.AspNetCore.Http;
using ShopOnline.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.WebAdmin.Helpers
{
    public static class WebAdminHelper
    {
        public static string GetToken(IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.Session.GetString(SystemValue.TOKEN_NAME);
        }
    }
}
