using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;

namespace App.Shared
{
    [Table("place_location")]
    public class PlaceLocation : BaseModel
    {
        private const string KeyLocationId = "location_id";
        private const string KeyLocationName = "location_name";
        private const string KeyLocationDescription = "location_description";
        private const string KeyPlaceId = "place_id";
        private const string KeyLatitude = "latitude";
        private const string KeyLongitude = "longitude";
        private const string KeyLocationCoverUrl = "location_cover_url";

        [Column(KeyLocationId)]
        [JsonProperty(KeyLocationId)]
        public int LocationId { get; set; }

        [Column(KeyLocationName)]
        [JsonProperty(KeyLocationName)]
        public string LocationName { get; set; }

        [Column(KeyLocationDescription)]
        [JsonProperty(KeyLocationDescription)]
        public string LocationDescription { get; set; }

        [Column(KeyPlaceId)]
        [JsonProperty(KeyPlaceId)]
        public int PlaceId { get; set; }

        [Column(KeyLatitude)]
        [JsonProperty(KeyLatitude)]
        public long LocationLatitude { get; set; }

        [Column(KeyLongitude)]
        [JsonProperty(KeyLongitude)]
        public long LocationLongitude { get; set; }

        [Column(KeyLocationCoverUrl)]
        [JsonProperty(KeyLocationCoverUrl)]
        public string LocationCoverUrl { get; set; }
    }
}

