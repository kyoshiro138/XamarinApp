using Xamarin.Core;
using System.Collections.Generic;

namespace App.Shared
{
    public interface IMenuScreen : IScreen
    {
        IListDataSource<MenuItem> GetMenuListDataSource(List<MenuItem> data);
    }
}

