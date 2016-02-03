using System.Collections.Generic;

namespace Xamarin.Core
{
    public interface IGridDataSource<T> where T : class
    {
        List<T> DataSource { get; set; }
    }
}

