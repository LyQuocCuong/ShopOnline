using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopOnline.Helpers.ShopOnlineApi
{
    public abstract class SOApiResult<T>
    {
        public bool IsSucceed { get; }

        public T ReturnedData { get; }

        public string ReturnedDataJSON
        {
            get
            {
                return this.ReturnedData != null ? JsonConvert.SerializeObject(this.ReturnedData) : "";
            }
        }

        public string Message { get; }

        protected SOApiResult(bool isSucceed)
        {
            IsSucceed = isSucceed;
        }

        protected SOApiResult(bool isSucceed, T returnedData)
        {
            IsSucceed = isSucceed;
            ReturnedData = returnedData;
        }

        protected SOApiResult(bool isSucceed, string message)
        {
            IsSucceed = isSucceed;
            Message = message;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}
