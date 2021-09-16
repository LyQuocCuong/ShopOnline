using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Helpers.ShopOnlineApi
{
    public class SOApiSuccessResult<T> : SOApiResult<T>
    {
        public SOApiSuccessResult() : base(true)
        { }

        public SOApiSuccessResult(T returnedData) :  base(true, returnedData)
        { }
    }
}
