using Xamarin.Core;
using Newtonsoft.Json;

namespace App.Shared
{
    public abstract class AppResponseObject : BaseResponseObject
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }
    }
}

