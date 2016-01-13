using Android.App;
using Android.OS;

namespace App.Android
{
    [Activity(Label = "App.Android", Theme = "@style/LightTheme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppDrawerActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            DatabaseManager = new AppAndroidDatabaseManager();
            await DatabaseManager.InitDatabase(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            SetContentFragment(new IntroFragment());
            SetLeftDrawerFragment(new MenuFragment());
        }
    }
}


