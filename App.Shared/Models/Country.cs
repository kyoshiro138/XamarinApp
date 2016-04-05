using System;
using SQLite.Net.Attributes;
using Newtonsoft.Json;

namespace App.Shared
{
    [Table("country")]
    public class Country
    {
        private const string KeyCountryId = "country_id";
        private const string KeyCountryName = "country_name";

        [Column(KeyCountryId)]
        [JsonProperty(KeyCountryId)]
        public int CountryId { get; set; }

        [Column(KeyCountryName)]
        [JsonProperty(KeyCountryName)]
        public string CountryName { get; set; }
    }
}

