using App.Shared;
using SQLite.Net.Interop;

namespace App.Android
{
    public class AppAndroidDatabaseManager : AppDatabaseManager
    {
        public AppAndroidDatabaseManager(ISQLitePlatform platform, string folderPath)
            : base(platform, folderPath)
        {
            
        }

        protected override bool IsDatabaseCreated(string dbPath)
        {
            return System.IO.File.Exists(dbPath);
        }
    }
}

