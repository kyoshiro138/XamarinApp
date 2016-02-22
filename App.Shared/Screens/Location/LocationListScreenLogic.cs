using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Core;

namespace App.Shared
{
    public class LocationListScreenLogic
    {
        private ILocationListScreen locationListScreen;

        public LocationListScreenLogic(ILocationListScreen screen)
        {
            locationListScreen = screen;
        }

        public async Task InitializeScreen(TravelPlace travelPlace)
        {
            if (travelPlace != null)
            {
                locationListScreen.Toolbar.Title = travelPlace.PlaceName;

                List<PlaceLocation> locations = await GetLocalLocationList(travelPlace.PlaceId);
                var dataSource = locationListScreen.GetLocationListDataSource(locations);
                var listLocation = locationListScreen.GetControlByTag(LocationListScreenConst.ControlListLocations) as IListView;
                listLocation.SetDataSource(dataSource);
            }
        }

        private async Task<List<PlaceLocation>> GetLocalLocationList(int placeId)
        {
            return await locationListScreen.TravelManager.GetLocalLocationList(placeId);
        }
    }
}

