using System;
using SQLite.Net.Attributes;

namespace Xamarin.Core
{
    [Table("db_info")]
    public class DatabaseInfo
    {
        [Column("version")]
        public int DBLocalVersion { get; set; }
    }
}

