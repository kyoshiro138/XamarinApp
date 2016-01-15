using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Xamarin.Core
{
    public interface IDatabase
    {
        int DBVersion { get; }

        Task<List<T>> GetAll<T>() where T : new();

        Task<T> GetFirst<T>() where T : new();

        Task<int> DeleteAll<T>() where T : new();

        Task<int> Delete<T>(int id) where T : new();

        Task<int> Insert<T>(T record) where T : new();
    }
}

