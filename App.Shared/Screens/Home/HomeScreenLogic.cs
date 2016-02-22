using System.Threading.Tasks;
using Xamarin.Core;
using System.Collections.Generic;

namespace App.Shared
{
    public class HomeScreenLogic
    {
        private IHomeScreen homeScreen;

        public HomeScreenLogic(IHomeScreen screen)
        {
            homeScreen = screen;
        }

        public async Task InitializeScreen()
        {
            homeScreen.Toolbar.Title = HomeScreenConst.StringScreenTitle;

            List<TravelPlace> places = await GetLocalPlaceList();
            if (places != null && places.Count > 0)
            {
                DisplayPlaceList(places);
            }
            else
            {
                await RequestTravelData();
            }
        }

        public async Task SaveTravelData(List<TravelPlace> data)
        {
            if (data != null && data.Count > 0)
            {
                await homeScreen.TravelManager.SaveTravelData(data);
            }
        }

        public async Task<List<TravelPlace>> GetLocalPlaceList()
        {
            return await homeScreen.TravelManager.GetLocalPlaceList();
        }

        public void DisplayPlaceList(List<TravelPlace> places)
        {
            var gridView = homeScreen.GetControlByTag(HomeScreenConst.ControlPlaceGrid) as IGridView;
            gridView.SetDataSource(homeScreen.GetPlaceGridDataSource(places));
        }

        public async Task RequestTravelData()
        {
            User currentUser = await homeScreen.UserManager.GetCurrentUser();
            await homeScreen.TravelManager.RequestTravelData(currentUser.Role);
        }

        public void HandlePlaceItemSelection(IGridDataSource<TravelPlace> dataSource, int position, IScreen locationListScreen)
        {
            if (dataSource != null && dataSource.DataSource != null && dataSource.DataSource.Count > position)
            {
                var selectedPlace = dataSource.DataSource[position];
                homeScreen.Navigator.NavigateTo<TravelPlace>(locationListScreen, selectedPlace, HomeScreenConst.ParamLocationList);
            }
        }
    }
}

