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
            await RequestData();
        }

        public async Task SaveTravelData(List<TravelPlace> data)
        {
            if (data != null && data.Count > 0)
            {
                await homeScreen.TravelManager.SaveTravelData(data);
            }
        }

        public async Task SaveCountries(List<Country> data)
        {
            if (data != null && data.Count > 0)
            {
                await homeScreen.TravelManager.SaveCountries(data);
            }
        }

        public async Task SaveUserProfile(User user)
        {
            if (user != null)
            {
                await homeScreen.UserManager.UpdateUserProfile(user);
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

        public async Task RequestData()
        {
            User currentUser = await homeScreen.UserManager.GetCurrentUser();
            await homeScreen.UserManager.RequestProfile(HomeScreenConst.ServiceGetProfile, currentUser.UserId);
            await homeScreen.TravelManager.RequestTravelData(HomeScreenConst.ServiceGetTravelData, currentUser.Role);
        }

        public void HandlePlaceItemSelection(IGridDataSource<TravelPlace> dataSource, int position, IScreen screen)
        {
            if (dataSource != null && dataSource.DataSource != null && dataSource.DataSource.Count > position)
            {
                var selectedPlace = dataSource.DataSource[position];
                homeScreen.Navigator.NavigateTo<TravelPlace>(screen, selectedPlace, HomeScreenConst.ParamPlaceInfo);
            }
        }
    }
}

