using Newtonsoft.Json;
using NFC_App.Model;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace NFC_App.Services
{
    public class ApiServices
    {
        public static string conectionSTR = "https://u1648633.plsk.regruhosting.ru";
        static HttpClient httpClient;
        public ApiServices()
        {
            httpClient = new HttpClient();
        }
        #region login/registr/refreshToken
        static async Task<bool> DoPost(Dictionary<string, string> parameter, string extensionURL)
        {
            try
            {
                string json = JsonConvert.SerializeObject(parameter, Formatting.Indented);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await httpClient.PostAsync(conectionSTR + extensionURL, content);
                if (response.IsSuccessStatusCode)
                {
                    UserRefreshToken token = TokenServices.JSONToRefreshToken(
                                             await response.Content.ReadAsStringAsync());

                    TokenServices.RefreshToken = token;
                    TokenServices.AccessToken = token.GetAccessToken();

                    await LocalDBServices.AddToken(token);

                    return true;
                }
                else return false;
            }
            catch
            {
                // можно поставить логирование
                return false;
            }
        }
        public static async Task<bool> LoginAsync(string login, string pass)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("Login", login);
            pass = Encript(pass);
            parameter.Add("Pass", pass);

            return await DoPost(parameter, "/Logon");
        }
        public static async Task<bool> RegistrAsync(string login, string pass)
        {
            Dictionary<string, string> parameter = new Dictionary<string, string>();
            //расширить данные
            parameter.Add("Login", login);
            pass = Encript(pass);
            parameter.Add("Pass", pass);

            return await DoPost(parameter, "/Registr");
        }
        public static async Task<bool> RefreshTokenAsync(UserRefreshToken refreshToken)
        {
            return await DoPost(refreshToken.GetRefreshDict(), "/RefreshToken");
        }
        private static string Encript(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        #endregion
        // переделть под HUB
        #region getData
        public static async Task<T> GetItem<T>(UserAccessToken accessToken, string extensionURL)
        {
            try
            {
                string json = JsonConvert.SerializeObject(accessToken.GetAccessDict(), Formatting.Indented);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                var response = await httpClient.PostAsync(conectionSTR + extensionURL, content);
                if (response.IsSuccessStatusCode)
                {
                    T items = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                    return items;
                }
                else return default(T);
            }
            catch
            {
                // можно поставить логирование
                return default(T);
            }
        }
        #endregion
    }
}
