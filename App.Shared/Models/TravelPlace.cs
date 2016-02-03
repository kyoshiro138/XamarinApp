using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;

namespace App.Shared
{
    [Table("travel_place")]
    public class TravelPlace
    {
        private const string KeyPlaceId = "place_id";
        private const string KeyPlaceName = "place_name";

        [PrimaryKey]
        [Column(KeyPlaceId)]
        [JsonProperty(KeyPlaceId)]
        public int PlaceId { get; set; }

        [NotNull]
        [Column(KeyPlaceName)]
        [JsonProperty(KeyPlaceName)]
        public string PlaceName { get; set; }
    }
}

