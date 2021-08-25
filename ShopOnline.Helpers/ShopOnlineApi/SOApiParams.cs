using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ShopOnline.Helpers.ShopOnlineApi
{
    public class SOApiParams
    {
        public IHttpClientFactory HttpClientFactory { get; }
        public string Token { get; }
        public string UrlPath { get; }
        public object BodyData { get; }

        public SOApiParams(IHttpClientFactory httpClientFactory,
                           string token, string urlPath, object bodyData = null)
        {
            HttpClientFactory = httpClientFactory;
            Token = token;
            UrlPath = urlPath;
            BodyData = bodyData;
        }
    }
}