using Newtonsoft.Json;

namespace App.Shared
{
    public class AuthenticationResponse : AppResponseObject
    {
        [JsonProperty("response")]
        public AuthenticationResponseData Data { get; set; }

        public class AuthenticationResponseData
        {
            [JsonProperty("key")]
            public string Key { get; set; }
        }
    }
}

