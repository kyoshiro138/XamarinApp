using System.Threading.Tasks;

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

        public async Task RequestTravelData()
        {
            User currentUser = await homeScreen.UserManager.GetCurrentUser();
            await homeScreen.TravelManager.RequestTravelData(currentUser.Role);
        }
    }
}

