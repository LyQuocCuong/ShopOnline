using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Helpers.ShopOnlineApi
{
    public class SOApiErrorResult<T> : SOApiResult<T>
    {
        public SOApiErrorResult(string message) : base (false, message)
        { }
    }
}
