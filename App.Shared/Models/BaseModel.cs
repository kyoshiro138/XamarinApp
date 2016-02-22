using System;
using SQLite.Net.Attributes;

namespace App.Shared
{
    public abstract class BaseModel
    {
        private const string KeyObjectId = "object_id";

        [PrimaryKey, AutoIncrement]
        [Column("object_id")]
        public int ObjectId { get; private set; }
    }
}

