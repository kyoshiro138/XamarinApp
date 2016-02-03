using Android.Views;
using App.Shared;
using Xamarin.Core;
using Android.Content;
using Xamarin.Core.Android;
using System;
using SQLite.Net.Platform.XamarinAndroid;
using System.Collections.Generic;

namespace App.Android
{
    public class HomeFragment : AppFragment, IHomeScreen
    {
        private IGridView PlaceGrid;

        private HomeScreenLogic homeSL;
        private DialogBuilder dialogBuilder;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_home; }
        }

        public UserManager UserManager { get; private set; }

        public TravelManager TravelManager { get; private set; }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
        }

        protected override void BindControls(View rootView)
        {
            PlaceGrid = rootView.FindViewById<SystemGridView>(Resource.Id.grid_places);
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
                case HomeScreenConst.ControlPlaceGrid:
                    return PlaceGrid;
                default:
                    return null;
            }
        }

        private void Service_OnResponseSuccess(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            switch (e.RequestTag)
            {
                case HomeScreenConst.ServiceGetTravelData:
                    HandleGetTravelDataResponse((GetTravelDataResponse)e.ResponseObject);
                    break;
            }
        }

        private void Service_OnResponseFailed(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            
        }

        public IGridDataSource<TravelPlace> GetPlaceGridDataSource(List<TravelPlace> places)
        {
            var adapter = new PlaceGridAdapter(Activity, places);
            return adapter;
        }

        private void HandleGetTravelDataResponse(GetTravelDataResponse response)
        {
            bool isSucceess = response.Status.Equals(true);
            if (isSucceess)
            {
                homeSL.DisplayPlaceList(response.Data.Places);
            }
        }
    }
}

