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

        public static async Task<string> ExecuteGetMethod(SOApiContentRequest contentApiRequest)
        {
            if (!string.IsNullOrEmpty(contentApiRequest.Token))
            {
                HttpClient httpClient = SetupConfig(contentApiRequest.HttpClientFactory, contentApiRequest.Token);
                var responseMessage = await httpClient.GetAsync(contentApiRequest.UrlPath);
                string contentApiResponse = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    //Log Here
                    //Error = contentApiResponse
                    return "";
                }
                return contentApiResponse;
            }
            return "Token Not Found";
        }

        public static async Task<string> ExecutePostMethodAnonymous(SOApiContentRequest contentApiRequest)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(contentApiRequest.Data), Encoding.UTF8, "application/json");
            HttpClient httpClient = SetupConfig(contentApiRequest.HttpClientFactory);
            var responseMessage = await httpClient.PostAsync(contentApiRequest.UrlPath, httpContent);
            string contentApiResponse = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)
            {
                //Log Here
                //Error = contentApiResponse
                return "";
            }
            return contentApiResponse;
        }

        public static async Task<string> ExecutePostMethod(SOApiContentRequest contentRequest)
        {
            if (!string.IsNullOrEmpty(contentRequest.Token))
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(contentRequest.Data), Encoding.UTF8, "application/json");
                HttpClient httpClient = SetupConfig(contentRequest.HttpClientFactory, contentRequest.Token);
                var response = await httpClient.PostAsync(contentRequest.UrlPath, httpContent);
                string jsonResult = await response.Content.ReadAsStringAsync();
                return jsonResult;
            }
            return "Token Not Found";
        }

    }
}
