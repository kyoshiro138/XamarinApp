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
            get { return 1; }
        }

        protected AppDatabaseManager(ISQLitePlatform platform, string folderPath)
            : base(platform, folderPath)
        {
            
        }

        public override async Task InitDatabase()
        {
            if (!IsDatabaseCreated(DBPath))
            {
                await InitTables();
            }
        }

        protected override async Task InitTables()
        {
            await DBConnection.CreateTableAsync<TravelPlace>();
            await DBConnection.CreateTableAsync<PlaceLocation>();
            await DBConnection.CreateTableAsync<User>();
        }

        protected void InitData()
        {

        }
    }
}

