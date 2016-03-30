using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.Shared
{
    [Table("travel_place")]
    public class TravelPlace : BaseModel
    {
        private const string KeyPlaceId = "place_id";
        private const string KeyPlaceName = "place_name";
        private const string KeyPlaceCoverUrl = "place_cover_url";
        private const string KeyLocations = "locations";

        [Column(KeyPlaceId)]
        [JsonProperty(KeyPlaceId)]
        public int PlaceId { get; set; }

        [Column(KeyPlaceName)]
        [JsonProperty(KeyPlaceName)]
        public string PlaceName { get; set; }

        [Column(KeyPlaceCoverUrl)]
        [JsonProperty(KeyPlaceCoverUrl)]
        public string PlaceCoverUrl { get; set; }

        [Ignore]
        [JsonProperty(KeyLocations)]
        public List<PlaceLocation> Locations { get; set; }
    }
}

