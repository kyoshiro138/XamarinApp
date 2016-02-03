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

        public void InitializeScreen()
        {
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
    }
}

