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
            httpClient.BaseAddress = new Uri(SystemValue.SHOPONLINE_API_BASE_ADDRESS);
            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders
                    .Authorization = new AuthenticationHeaderValue(SystemValue.PREFIX_TOKEN, token);
            }
            return httpClient;
        }

        public static async Task<SOApiResult<T>> ExecutePostMethodAnonymous<T>(IHttpClientFactory httpClientFactory, string urlPath, object bodyData)
        {
            var httpContent = new StringContent(JsonConvert.SerializeObject(bodyData), Encoding.UTF8, "application/json");
            HttpClient httpClient = SetupConfig(httpClientFactory);
            var responseMessage = await httpClient.PostAsync(urlPath, httpContent);
            string returnedContent = await responseMessage.Content.ReadAsStringAsync();
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new SOApiErrorResult<T>(returnedContent);
            }
            return typeof(T) == typeof(bool)
                                ? new SOApiSuccessResult<T>()
                                : new SOApiSuccessResult<T>(JsonConvert.DeserializeObject<T>(returnedContent));
        }

        public static async Task<SOApiResult<T>> ExecuteGetMethod<T>(SOApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var responseMessage = await httpClient.GetAsync(apiParams.UrlPath);
                string returnedContent = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    return new SOApiErrorResult<T>(returnedContent);
                }
                return typeof(T) == typeof(bool)
                                ? new SOApiSuccessResult<T>()
                                : new SOApiSuccessResult<T>(JsonConvert.DeserializeObject<T>(returnedContent));
            }
            return new SOApiErrorResult<T>("Token Not Found");
        }

        public static async Task<SOApiResult<T>> ExecutePostMethod<T>(SOApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(apiParams.BodyData), Encoding.UTF8, "application/json");
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var responseMessage = await httpClient.PostAsync(apiParams.UrlPath, httpContent);
                string returnedContent = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    return new SOApiErrorResult<T>(returnedContent);
                }
                return typeof(T) == typeof(bool) 
                                ? new SOApiSuccessResult<T>()
                                : new SOApiSuccessResult<T>(JsonConvert.DeserializeObject<T>(returnedContent));
            }
            return new SOApiErrorResult<T>("Token Not Found");
        }

        public static async Task<SOApiResult<T>> ExecutePutMethod<T>(SOApiParams apiParams)
        {
            if (!string.IsNullOrEmpty(apiParams.Token))
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(apiParams.BodyData), Encoding.UTF8, "application/json");
                HttpClient httpClient = SetupConfig(apiParams.HttpClientFactory, apiParams.Token);
                var responseMessage = await httpClient.PutAsync(apiParams.UrlPath, httpContent);
                string returnedContent = await responseMessage.Content.ReadAsStringAsync();
                if (!responseMessage.IsSuccessStatusCode)
                {
                    return new SOApiErrorResult<T>(returnedContent);
                }
                return typeof(T) == typeof(bool)
                                ? new SOApiSuccessResult<T>()
                                : new SOApiSuccessResult<T>(JsonConvert.DeserializeObject<T>(returnedContent));
            }
            return new SOApiErrorResult<T>("Token Not Found");
        }

    }
}
