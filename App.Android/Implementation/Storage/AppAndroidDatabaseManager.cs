using App.Shared;

namespace App.Android
{
    public class AppAndroidDatabaseManager : AppDatabaseManager
    {
        public AppAndroidDatabaseManager()
            : base()
        {
            
        }

        protected override bool IsDatabaseCreated(string dbPath)
        {
            return System.IO.File.Exists(dbPath);
        }
    }
}

