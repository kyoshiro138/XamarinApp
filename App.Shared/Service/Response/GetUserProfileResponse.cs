using System;
using Newtonsoft.Json;

namespace App.Shared
{
    public class GetUserProfileResponse : AppResponseObject
    {
        [JsonProperty("response")]
        public GetUserProfileResponseData Data { get; set; }

        public class GetUserProfileResponseData
        {
            [JsonProperty("user")]
            public User User { get; set; }
        }
    }
}

