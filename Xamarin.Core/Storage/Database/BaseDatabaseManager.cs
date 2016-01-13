using SQLite.Net.Interop;
using SQLite.Net.Async;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Xamarin.Core
{
    public abstract class BaseDatabaseManager : IDatabaseManager
    {
        public abstract string DBName { get; }

        public abstract int DBVersion { get; }

        protected SQLiteAsyncConnection DBConnection { get; set; }

        protected BaseDatabaseManager()
        {
        }

        public abstract Task InitDatabase(ISQLitePlatform platform, string folderPath);

        protected abstract void InitTables();

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
    }
}

