using Android.App;
using Android.OS;
using App.Shared;
using Xamarin.Core.Android;
using Android.Views;
using System.Threading.Tasks;

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
            Window.SetFlags(WindowManagerFlags.TranslucentStatus, WindowManagerFlags.TranslucentStatus);

            MenuFragment = new MenuFragment();

            SetContentFragment(new IntroFragment());
            SetLeftDrawerFragment(MenuFragment);
        }

        public async void LoadMenu()
        {
            await MenuFragment.LoadMenu();
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


