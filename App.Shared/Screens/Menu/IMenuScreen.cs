using Xamarin.Core;
using System.Collections.Generic;

namespace App.Shared
{
    public interface IMenuScreen : IScreen, INavigationScreen
    {
        UserManager UserManager { get; }

        IListDataSource<MenuItem> GetMenuListDataSource(List<MenuItem> data);

        IDialog BuildSignOutConfirmationDialog();
    }
}

