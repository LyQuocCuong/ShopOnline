using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Utilities.Consts
{
    public static class SystemConst
    {
        #region TOKEN - AUTHENTICATE

        public static readonly string TOKEN_NAME = "Token";
        public static readonly int TIMELIFE_COOKIE_MINUTES = 30;
        public static readonly int TIMELIFE_SESSION_MINUTES = 30;
        public static readonly int TIMELIFE_TOKEN_MINUTES = 30;

        #endregion

        #region BACKEND_API

        public static readonly string SHOPONLINE_API_BASE_ADDRESS = "https://localhost:44315";
        public static readonly string PREFIX_TOKEN = "Bearer";
        
        #endregion

    }
}
