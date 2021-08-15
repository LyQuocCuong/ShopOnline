using Newtonsoft.Json;
using ShopOnline.Helpers.ShopOnlineApi;
using ShopOnline.Utilities.Consts;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Helpers.ShopOnlineApi
{
    public static class ShopOnlineApiHelper
    {
        private static HttpClient SetupConfig(IHttpClientFactory httpClientFactory, string token = null)
        {
            HttpClient httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(SystemConst.SHOPONLINE_API_BASE_ADDRESS);
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders
                    .Authorization = new AuthenticationHeaderValue(SystemConst.PREFIX_TOKEN, token);
            }
            return httpClient;
        }

        public static async Task<string> GetMethod(ShopOnlineApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var response = await httpClient.GetAsync(apiParams.UrlPath);
                string jsonResult = await response.Content.ReadAsStringAsync();
                return jsonResult;
            }
            return "Token Not Found";
        }

        public static async Task<string> PostMethodAnonymous(ShopOnlineApiParams apiParams)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(apiParams.Content), Encoding.UTF8, "application/json");
            HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory);
            var response = await httpClient.PostAsync(apiParams.UrlPath, httpContent);
            string jsonResult = await response.Content.ReadAsStringAsync();
            return jsonResult;
        }

        public static async Task<string> PostMethod(ShopOnlineApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(apiParams.Content), Encoding.UTF8, "application/json");
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var response = await httpClient.PostAsync(apiParams.UrlPath, httpContent);
                string jsonResult = await response.Content.ReadAsStringAsync();
                return jsonResult;
            }
            return "Token Not Found";
        }

    }
}
