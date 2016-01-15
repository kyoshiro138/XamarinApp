using System;
using System.Threading.Tasks;
using Xamarin.Core;

namespace App.Shared
{
    public class IntroScreenLogic
    {
        private readonly IIntroScreen introScreen;

        public IntroScreenLogic(IIntroScreen screen)
        {
            introScreen = screen;
        }

        public void InitializeScreen()
        {
            var lblTitle = introScreen.GetControlByTag(IntroScreenConst.ControlLabelTitle) as ILabel;
            lblTitle.Text = IntroScreenConst.StringIntroTitle;
        }

        public async Task<bool> IsUserSignedIn()
        {
            User user = await introScreen.UserManager.GetCurrentUser();
            return (user != null);
        }

        public async Task NavigateWithDelay(IScreen screen)
        {
            await Task.Delay(IntroScreenConst.IntroTimeSeconds);
            introScreen.Navigator.NavigateTo(screen, true);
        }
    }
}

