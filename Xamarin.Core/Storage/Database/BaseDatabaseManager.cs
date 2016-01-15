using SQLite.Net.Interop;
using SQLite.Net.Async;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using SQLite.Net;

namespace Xamarin.Core
{
    public abstract class BaseDatabaseManager : IDatabase
    {
        protected SQLiteAsyncConnection DBConnection { get; set; }

        protected string DBPath { get; private set; }

        public abstract string DBName { get; }

        public abstract int DBVersion { get; }

        protected BaseDatabaseManager(ISQLitePlatform platform, string folderPath)
        {
            DBPath = Path.Combine(folderPath, DBName);
            DBConnection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, new SQLiteConnectionString(DBPath, false)));
        }

        public abstract Task InitDatabase();

        protected abstract Task InitTables();

        protected abstract bool IsDatabaseCreated(string dbPath);

        public async Task<List<T>> GetAll<T>() where T : new()
        {
            var result = await DBConnection.Table<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetFirst<T>() where T : new()
        {
            var result = await DBConnection.Table<T>().FirstOrDefaultAsync();
            return result;
        }

        public async Task<int> DeleteAll<T>() where T : new()
        {
            return await DBConnection.DeleteAllAsync<T>();
        }

        public async Task<int> Delete<T>(int id) where T : new()
        {
            return await DBConnection.DeleteAsync(id);
        }

        public async Task<int> Insert<T>(T record) where T : new()
        {
            return await DBConnection.InsertAsync(record);
        }
    }
}

