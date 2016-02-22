using System;
using Newtonsoft.Json;
using SQLite.Net.Attributes;

namespace App.Shared
{
    [Table("user")]
    public class User : BaseModel
    {
        private const string KeyUserId = "user_id";
        private const string KeyUsername = "username";
        private const string KeyUserType = "role";
        private const string KeyFirstName = "first_name";
        private const string KeyLastName = "last_name";
        private const string KeyAvatarUrl = "avatar_url";
        private const string KeyDOB = "dob";
        private const string KeyGender = "gender";

        public const string GenderMale = "Male";
        public const string GenderFemale = "Female";
        public const string GenderUndefined = "Undefined";

        [JsonProperty(KeyUserId)]
        [Column(KeyUserId)]
        public int UserId { get; set; }

        [JsonProperty(KeyUsername)]
        [Column(KeyUsername)]
        public string Username { get; set; }

        [JsonProperty(KeyUserType)]
        [Column(KeyUserType)]
        public int Role { get; set; }

        [JsonProperty(KeyFirstName)]
        [Column(KeyFirstName)]
        public string FirstName { get; set; }

        [JsonProperty(KeyLastName)]
        [Column(KeyLastName)]
        public string LastName { get; set; }

        [JsonProperty(KeyAvatarUrl)]
        [Ignore]
        public string AvatarUrl { get; set; }

        [JsonProperty(KeyDOB)]
        [Ignore]
        public string DateOfBirth { get; set; }

        [JsonProperty(KeyGender)]
        [Ignore]
        public int Gender { get; set; }

        public DateTime? GetDOBByDate(string format, IFormatProvider provider)
        {
            DateTime dob;
            if (!string.IsNullOrEmpty(DateOfBirth) && DateTime.TryParseExact(DateOfBirth, format, provider, System.Globalization.DateTimeStyles.None, out dob))
            {
                return dob;
            }
            return null;
        }

        public string GetGenderByString()
        {
            if (Gender == 0)
            {
                return GenderMale;
            }
            else if (Gender == 1)
            {
                return GenderFemale;
            }
            return GenderUndefined;
        }

        public enum GenderType
        {
            Male = 0,
            Female = 1
        }

        public enum RoleType
        {
            Guest = 0,
            Member = 1
        }
    }
}

