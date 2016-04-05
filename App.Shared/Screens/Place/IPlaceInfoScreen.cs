using System;
using Xamarin.Core;

namespace App.Shared
{
    public interface IPlaceInfoScreen : IScreen, INavigationScreen
    {
        TravelManager TravelManager { get; }
    }
}

