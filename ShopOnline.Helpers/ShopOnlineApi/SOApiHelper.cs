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
    public static class SOApiHelper
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

        public static async Task<string> ExecutePostMethodAnonymous(IHttpClientFactory httpClientFactory, string urlPath, object bodyData)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(bodyData), Encoding.UTF8, "application/json");
            HttpClient httpClient = SetupConfig(httpClientFactory);
            var responseMessage = await httpClient.PostAsync(urlPath, httpContent);
            string contentApiResponse = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)
            {
                //Log Here
                //Error = contentApiResponse
                return "";
            }
            return contentApiResponse;
        }

        public static async Task<string> ExecuteGetMethod(SOApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var responseMessage = await httpClient.GetAsync(apiParams.UrlPath);
                string contentResponse = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    //Log Here
                    //Error = contentResponse
                    return "";
                }
                return contentResponse;
            }
            return "Token Not Found";
        }

        public static async Task<string> ExecutePostMethod(SOApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(apiParams.BodyData), Encoding.UTF8, "application/json");
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var responseMessage = await httpClient.PostAsync(apiParams.UrlPath, httpContent);
                string contentResponse = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    //Log Here
                    //Error = contentResponse
                    return "";
                }
                return contentResponse;
            }
            return "Token Not Found";
        }

        public static async Task<string> ExecutePutMethod(SOApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(apiParams.BodyData), Encoding.UTF8, "application/json");
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var responseMessage = await httpClient.PutAsync(apiParams.UrlPath, httpContent);
                string contentResponse = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    //Log Here
                    //Error = contentResponse
                    return "";
                }
                return contentResponse;
            }
            return "Token Not Found";
        }

    }
}
