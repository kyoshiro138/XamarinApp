using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.Shared
{
    public class GetTravelDataResponse : AppResponseObject
    {
        [JsonProperty("response")]
        public GetTravelDataResponseData Data { get; set; }

        public class GetTravelDataResponseData
        {
            [JsonProperty("places")]
            public List<TravelPlace> Places { get; set; }

            [JsonProperty("countries")]
            public List<Country> Countries { get; set; }
        }
    }
}

