using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ShopOnline.Utilities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.WebAdmin.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Why need to do that ?
            //We need the Token for calling every API request and API authen by JWT mechanism
            var token = context.HttpContext.Session.GetString(SystemConst.TOKEN_NAME);
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new RedirectToActionResult("Login", "Index", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
