using Xamarin.Core;
using Newtonsoft.Json;

namespace App.Shared
{
    public abstract class AppResponseObject : BaseResponseObject
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("code")]
        public int ErrorCode { get; set; }

        [JsonProperty("message")]
        public string ErrorMessage { get; set; }
    }
}

