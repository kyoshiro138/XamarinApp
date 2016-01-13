using System;
using Xamarin.Core;
using System.Threading.Tasks;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using SQLite.Net;
using System.IO;

namespace App.Shared
{
    public abstract class AppDatabaseManager : BaseDatabaseManager
    {
        public override string DBName
        {
            get { return "AppDB.db"; }
        }

        public override int DBVersion
        {
            get { return 2; }
        }

        protected AppDatabaseManager()
            : base()
        {
            
        }

        public override async Task InitDatabase(ISQLitePlatform platform, string folderPath)
        {
            string dbPath = Path.Combine(folderPath, DBName);
            DBConnection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, new SQLiteConnectionString(dbPath, false)));

            if (IsDatabaseCreated(dbPath))
            {
                bool isLatestDBVersion = await IsLatestDatabaseVersion();
                if (isLatestDBVersion)
                {
                    await UpdateDatabaseInfo();
                }
            }
            else
            {
                await InitDatabaseInfo();
            }
        }

        private async Task InitDatabaseInfo()
        {
            await DBConnection.CreateTableAsync<DatabaseInfo>();
            await DBConnection.InsertAsync(new DatabaseInfo()
                {
                    DBLocalVersion = DBVersion
                });
        }

        private async Task<bool> IsLatestDatabaseVersion()
        {
            var dbInfo = await GetFirst<DatabaseInfo>();
            if (dbInfo.DBLocalVersion.Equals(DBVersion))
            {
                return true;
            }
            return false;
        }

        private async Task UpdateDatabaseInfo()
        {
            await DBConnection.DeleteAllAsync<DatabaseInfo>();
            await DBConnection.InsertAsync(new DatabaseInfo()
                {
                    DBLocalVersion = DBVersion
                });
        }

        protected override void InitTables()
        {
        }
    }
}

