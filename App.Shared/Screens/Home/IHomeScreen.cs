using Xamarin.Core;
using System.Collections.Generic;

namespace App.Shared
{
    public interface IHomeScreen : IScreen
    {
        UserManager UserManager { get; }

        TravelManager TravelManager { get; }

        IGridDataSource<TravelPlace> GetPlaceGridDataSource(List<TravelPlace> places);
    }
}

