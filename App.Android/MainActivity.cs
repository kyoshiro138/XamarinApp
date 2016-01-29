using Android.App;
using Android.OS;
using App.Shared;
using Xamarin.Core.Android;

namespace App.Android
{
    [Activity(Label = "App.Android", Theme = "@style/AppLightTheme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppDrawerActivity
    {
        private MenuFragment MenuFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ApplyTheme();
            base.OnCreate(savedInstanceState);

            MenuFragment = new MenuFragment();

            SetContentFragment(new IntroFragment());
            SetLeftDrawerFragment(MenuFragment);
        }

        public void LoadMenu()
        {
            MenuFragment.LoadMenu();
        }

        private void ApplyTheme()
        {
            var preference = new ApplicationPreferences();
            string theme = preference.LoadString(AppStorageKeys.ApplicationTheme, "LIGHT");
            if (theme.Equals("LIGHT"))
            {
                SetTheme(Resource.Style.AppLightTheme);
            }
            else if (theme.Equals("DARK"))
            {
                SetTheme(Resource.Style.AppDarkTheme);
            }
        }
    }
}


