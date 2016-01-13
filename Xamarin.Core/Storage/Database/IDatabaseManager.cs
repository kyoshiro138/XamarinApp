using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Xamarin.Core
{
    public interface IDatabaseManager
    {
        int DBVersion { get; }

        Task<List<T>> GetAll<T>() where T : new();

        Task<T> GetFirst<T>() where T : new();
    }
}

