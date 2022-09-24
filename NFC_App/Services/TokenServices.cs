using Newtonsoft.Json;
using NFC_App.Model;

namespace NFC_App.Services
{
    public class TokenServices
    {
        public static UserRefreshToken RefreshToken
        {
            get
            {
                if (RefreshToken != null) return RefreshToken;
                else
                {
                    RefreshToken = LocalDBServices.GetToken().Result;
                    return RefreshToken;
                }
            }
            set
            {
                RefreshToken = value;
            }
        }
        public static UserAccessToken AccessToken 
        {
            get 
            {
                if(AccessToken != null) return AccessToken;
                else
                {
                    AccessToken = LocalDBServices.GetToken().Result.GetAccessToken();
                    return AccessToken;
                }
            } 
            set 
            {
                AccessToken = value;
            }
        }

        public static string TokenToJSON(UserAccessToken token)
        {
            Dictionary<string, string> param = token.GetAccessDict();
            //после теста удали 
            var d = JsonConvert.SerializeObject(param, Formatting.Indented);
            return JsonConvert.SerializeObject(param, Formatting.Indented);
        }
        public static string TokenToJSON(UserRefreshToken token)
        {
            Dictionary<string, string> param = token.GetRefreshDict();
            //после теста удали 
            var d = JsonConvert.SerializeObject(param, Formatting.Indented);
            return JsonConvert.SerializeObject(param, Formatting.Indented);
        }
        public static UserAccessToken JSONToAccessToken(string json)
        {
            //после теста удали 
            var test = JsonConvert.DeserializeObject<UserAccessToken>(json);
            return JsonConvert.DeserializeObject<UserAccessToken>(json);
        }
        public static UserRefreshToken JSONToRefreshToken(string json)
        {
            //после теста удали 
            var test = JsonConvert.DeserializeObject<UserRefreshToken>(json);
            return JsonConvert.DeserializeObject<UserRefreshToken>(json);
        }
    }
}
