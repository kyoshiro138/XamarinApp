using Android.Views;
using App.Shared;
using Xamarin.Core;
using Xamarin.Core.Android;
using System;
using SQLite.Net.Platform.XamarinAndroid;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Widget;

namespace App.Android
{
    public class HomeFragment : AppFragment, IHomeScreen
    {
        private AnimationGridView gridPlaces;

        private HomeScreenLogic homeSL;
        private DialogBuilder dialogBuilder;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_home; }
        }

        protected override void BindControls(View rootView)
        {
            gridPlaces = rootView.FindViewById<AnimationGridView>(Resource.Id.grid_places);
            gridPlaces.SetAnimation(Resource.Animation.anim_grid_enter, Resource.Animation.anim_grid_exit);
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
        }

        public override async void OnResume()
        {
            base.OnResume();
            DrawerActivity.SetDrawersEnabled(true);
            Toolbar.Show();

            gridPlaces.ItemClick += GridPlaces_ItemClick;

            MainActivity activity = DrawerActivity as MainActivity;
            if (activity != null)
            {
                activity.LoadMenu();
            }

            await homeSL.InitializeScreen();
        }

        public override void OnPause()
        {
            base.OnPause();

            gridPlaces.ItemClick -= GridPlaces_ItemClick;
        }

        public IControl GetControlByTag(string tag)
        {
            switch (tag)
            {
                case HomeScreenConst.ControlPlaceGrid:
                    return gridPlaces;
                default:
                    return null;
            }
        }

        private async void Service_OnResponseSuccess(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            switch (e.RequestTag)
            {
                case HomeScreenConst.ServiceGetTravelData:
                    await HandleGetTravelDataResponse((GetTravelDataResponse)e.ResponseObject);
                    break;
                case HomeScreenConst.ServiceGetProfile:
                    await HandleGetUserProfileResponse((GetUserProfileResponse)e.ResponseObject);
                    break;
            }
        }

        private async void Service_OnResponseFailed(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            List<TravelPlace> places = await homeSL.GetLocalPlaceList();
            if (places != null && places.Count > 0)
            {
                homeSL.DisplayPlaceList(places);
            }
        }

        public IGridDataSource<TravelPlace> GetPlaceGridDataSource(List<TravelPlace> places)
        {
            var adapter = new PlaceGridAdapter(Activity, places);
            return adapter;
        }

        private async Task HandleGetTravelDataResponse(GetTravelDataResponse response)
        {
            bool isSucceess = response.Status.Equals(true);
            if (isSucceess)
            {
                await homeSL.SaveTravelData(response.Data.Places);
                List<TravelPlace> places = await homeSL.GetLocalPlaceList();
                homeSL.DisplayPlaceList(places);
            }
        }

        private async Task HandleGetUserProfileResponse(GetUserProfileResponse response)
        {
            bool isSucceess = response.Status.Equals(true);
            if (isSucceess)
            {
                await homeSL.SaveUserProfile(response.Data.User);
                MainActivity activity = DrawerActivity as MainActivity;
                if (activity != null)
                {
                    activity.LoadMenu();
                }
            }
        }

        private void GridPlaces_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            AnimationGridView gridView = e.Parent as AnimationGridView;
            IGridDataSource<TravelPlace> adapter = gridView.Adapter as IGridDataSource<TravelPlace>;
            homeSL.HandlePlaceItemSelection(adapter, e.Position, new LocationListFragment());
        }
    }
}

