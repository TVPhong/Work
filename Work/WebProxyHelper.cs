using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
    public static class WebProxyHelper
    {
        public const string BaseAddress = "https://www.howkteam.vn/account/login?ReturnUrl=%2F";

        public static string GetAuthenticatedResponse()
        {
            var client = new HttpClient();
            var token = TokenHelper.GetAccessToken();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Result.AccessToken); // Set up Header
            var authorizedResponse = client.GetAsync(BaseAddress + "api/test").Result;
            //var authorizedResponse = WebProxyHelper.GetAuthenticatedResponse();
            var resultString = authorizedResponse.Content.ReadAsStringAsync().Result;

            return resultString; // ideally, if the result is JSON, deserialize it and return. 
        }

        private sealed class Encoder
        {
            private const string _hasher = "";
        }
    }

   
}
