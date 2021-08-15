﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ShopOnline.Helpers.ShopOnlineApi
{
    public class ShopOnlineApiParams
    {
        public IHttpClientFactory HttpClientFactory { get; set; }
        public string Token { get; set; }
        public string UrlPath { get; set; }
        public object Content { get; set; }
    }
}