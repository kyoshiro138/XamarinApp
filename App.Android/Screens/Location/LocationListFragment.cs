using System.Collections.Generic;
using Android.OS;
using Android.Views;
using App.Shared;
using Newtonsoft.Json;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Core;
using Xamarin.Core.Android;

namespace App.Android
{
    public class LocationListFragment : AppFragment<TravelPlace>, ILocationListScreen
    {
        private SystemListView listLocations;

        private LocationListScreenLogic locationListSL;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_location_list; }
        }

        protected override void BindControls(View rootView)
        {
            listLocations = rootView.FindViewById<SystemListView>(Resource.Id.list_locations);
        }

        protected override void LoadData()
        {
            var database = new AppAndroidDatabaseManager(new SQLitePlatformAndroid(), System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            TravelManager = new TravelManager(null, database, null);

            locationListSL = new LocationListScreenLogic(this);
        }

        public override async void OnResume()
        {
            base.OnResume();
            DrawerActivity.SetDrawersEnabled(true);
            Toolbar.Show();

            await locationListSL.InitializeScreen(ReceivedParam);
        }

        public IControl GetControlByTag(string tag)
        {
            switch(tag)
            {
                case LocationListScreenConst.ControlListLocations:
                    return listLocations;
            }
            return null;
        }

        public IListDataSource<PlaceLocation> GetLocationListDataSource(List<PlaceLocation> places)
        {
            var adapter = new LocationListAdapter(Activity, places);
            return adapter;
        }

        public override TravelPlace ReceiveParamObject(Bundle param, string tag)
        {
            if(param!=null)
            {
                string paramString = param.GetString(tag, "");
                if(!string.IsNullOrEmpty(paramString))
                {
                    var paramObject = JsonConvert.DeserializeObject<TravelPlace>(paramString);
                    return paramObject;
                }
            }
            return null;
        }
    }
}

