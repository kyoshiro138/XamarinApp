using System;
using SQLite.Net.Attributes;

namespace App.Shared
{
    [Table("place_location")]
    public class PlaceLocation
    {
        [PrimaryKey, AutoIncrement]
        [Column("location_id")]
        public int LocationId { get; set; }

        [NotNull]
        [Column("location_name")]
        public string LocationName { get; set; }

        [NotNull]
        [Column("place_id")]
        public int PlaceId { get; set; }

        [NotNull]
        [Column("location_lat")]
        public long LocationLatitude { get; set; }

        [NotNull]
        [Column("location_lng")]
        public long LocationLongitude { get; set; }
    }
}

