using System;
using Newtonsoft.Json;

namespace App.Shared
{
    public class User
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}

