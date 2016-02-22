using Xamarin.Core;
using System.Collections.Generic;

namespace App.Shared
{
    public interface ILocationListScreen : IScreen, IToolbarScreen
    {
        TravelManager TravelManager { get; }

        IListDataSource<PlaceLocation> GetLocationListDataSource(List<PlaceLocation> places);
    }
}

