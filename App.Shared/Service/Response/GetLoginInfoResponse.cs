using System;
using Newtonsoft.Json;

namespace App.Shared
{
    public class GetLoginInfoResponse : AppResponseObject
    {
        [JsonProperty("response")]
        public GetLoginInfoResponseData Data { get; set; }

        public class GetLoginInfoResponseData
        {
            [JsonProperty("user")]
            public User User { get; set; }
        }
    }
}

