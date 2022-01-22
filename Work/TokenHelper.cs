using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Work
{
        public static class TokenHelper
        {
            private const string Username = "tranvanphong26598";
            private const string Password = "Tvp26598@";
            public const string BaseAddress = "https://www.howkteam.vn/account/login?ReturnUrl=%2F";

            public static async Task<AuthToken> GetAccessToken()
            {
                var client = new HttpClient(); // khởi tạo httpclient
                var authorizationHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(Username + ":" + Password));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationHeader);
                var form = new Dictionary<string, string>
               {
                   {"grant_type", "password"},
                   {"username", Username},
                   {"password", Password},
               };

            // FormUrlEncodedContent :  tạo Content tương ứng như một Form HTML, nó chứa các giá trị (key/value) sẽ Post đến Server.
            var tokenResponse = await client.PostAsync(BaseAddress + "token", new FormUrlEncodedContent(form));

                return await tokenResponse.Content.ReadAsAsync<AuthToken>(new[] { new JsonMediaTypeFormatter() }); // trả về ND 
            }
        }
}
