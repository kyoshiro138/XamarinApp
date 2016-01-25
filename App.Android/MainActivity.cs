using Android.App;
using Android.OS;
using App.Shared;

namespace App.Android
{
    [Activity(Label = "App.Android", Theme = "@style/AppLightTheme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppDrawerActivity
    {
        private MenuFragment MenuFragment;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            MenuFragment = new MenuFragment();

            SetContentFragment(new IntroFragment());
            SetLeftDrawerFragment(MenuFragment);
        }

        public void LoadMenu()
        {
            MenuFragment.LoadMenu();
        }
    }
}


