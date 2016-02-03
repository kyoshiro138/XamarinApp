using Android.Views;
using App.Shared;
using Xamarin.Core;
using Android.Content;
using Xamarin.Core.Android;
using System;
using SQLite.Net.Platform.XamarinAndroid;

namespace App.Android
{
    public class HomeFragment : AppFragment, IHomeScreen
    {
        private HomeScreenLogic homeSL;
        private DialogBuilder dialogBuilder;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_content; }
        }

        public UserManager UserManager { get; private set; }

        public TravelManager TravelManager { get; private set; }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
        }

        protected override void BindControls(View rootView)
        {
        }

        protected override void LoadData()
        {
            dialogBuilder = new DialogBuilder(Context);

            var service = new AppService(Context);
            service.OnResponseSuccess += Service_OnResponseSuccess;
            service.OnResponseFailed += Service_OnResponseFailed;
            service.Dialog = new SystemProgressDialog(Activity);

            var database = new AppAndroidDatabaseManager(new SQLitePlatformAndroid(), Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            var appPref = new ApplicationPreferences();

            UserManager = new UserManager(service, database, appPref);
            TravelManager = new TravelManager(service, database, appPref);

            homeSL = new HomeScreenLogic(this);
            homeSL.InitializeScreen();
        }

        public override async void OnResume()
        {
            base.OnResume();
            DrawerActivity.SetDrawersEnabled(true);
            Toolbar.Show();

            MainActivity activity = DrawerActivity as MainActivity;
            if (activity != null)
            {
                activity.LoadMenu();
            }

            await homeSL.RequestTravelData();
        }

        public IControl GetControlByTag(string tag)
        {
            switch (tag)
            {
                default:
                    return null;
            }
        }

        private void Service_OnResponseSuccess(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            switch (e.RequestTag)
            {
                case HomeScreenConst.ServiceGetTravelData:
                    break;
            }
        }

        private void Service_OnResponseFailed(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            
        }
    }
}

