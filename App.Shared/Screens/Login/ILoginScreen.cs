using System;
using Xamarin.Core;

namespace App.Shared
{
    public interface ILoginScreen : IScreen, INavigationScreen
    {
        UserManager UserManager { get; }
    }
}

