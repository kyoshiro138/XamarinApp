using System;
using System.Collections.Generic;

namespace Xamarin.Core
{
    public interface IListDataSource<T> where T : class
    {
        List<T> DataSource { get; set; }
    }
}

