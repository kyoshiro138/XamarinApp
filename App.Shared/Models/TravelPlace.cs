using System;
using SQLite.Net.Attributes;

namespace App.Shared
{
    [Table("travel_place")]
    public class TravelPlace
    {
        [PrimaryKey, AutoIncrement]
        [Column("place_id")]
        public int PlaceId { get; set; }

        [NotNull]
        [Column("place_name")]
        public string PlaceName { get; set; }
    }
}

