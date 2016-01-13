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

        public bool IsUserSignedIn()
        {
            return false;
        }

        public async Task NavigateWithDelay(IScreen screen)
        {
            await Task.Delay(IntroScreenConst.IntroTimeSeconds);
            introScreen.Navigator.NavigateTo(screen);
        }

        public async Task LoadDBVersion()
        {
            int newVersion = introScreen.DatabaseManager.DBVersion;
            DatabaseInfo localDBInfo = await introScreen.DatabaseManager.GetFirst<DatabaseInfo>();

            var lblDBVersion = introScreen.GetControlByTag(IntroScreenConst.ControlLabelDBVersion) as ILabel;
            string versionString = string.Format("{0}({1})", localDBInfo.DBLocalVersion, newVersion);
            lblDBVersion.Text = string.Format(IntroScreenConst.StringDBVersionFormat, versionString);
        }
    }
}

