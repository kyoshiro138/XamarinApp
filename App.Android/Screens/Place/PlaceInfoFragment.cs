using System;
using Android.Views;
using App.Shared;
using Android.OS;
using Newtonsoft.Json;
using Xamarin.Core.Android;
using Xamarin.Core;
using SQLite.Net.Platform.XamarinAndroid;
using Android.Widget;

namespace App.Android
{
    public class PlaceInfoFragment : AppFragment<TravelPlace>, IPlaceInfoScreen
    {
        private FFImageLoadingView ivPlaceCover;
        private MaterialLabel lblPlaceName;
        private MaterialLabel lblPlaceSubname;
        private MaterialLabel lblPlaceDescription;
        private MaterialLabel lblPlaceRating;
        private MaterialLabel lblTravelerCount;
        private MaterialButton btnLocations;

        private PlaceInfoScreenLogic placeInfoSL;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_place_info; }
        }

        protected override void BindControls(View rootView)
        {
            ivPlaceCover = rootView.FindViewById<FFImageLoadingView>(Resource.Id.iv_place_image);
            lblPlaceName = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_place_name);
            lblPlaceSubname = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_place_subname);
            lblPlaceDescription = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_place_description);
            lblPlaceRating = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_place_rate);
            lblTravelerCount = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_place_traveler_count);
            btnLocations = rootView.FindViewById<MaterialButton>(Resource.Id.btn_place_locations);
        }

        protected override void LoadData()
        {
            placeInfoSL = new PlaceInfoScreenLogic(this);

            var database = new AppAndroidDatabaseManager(new SQLitePlatformAndroid(), System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));

            TravelManager = new TravelManager(null, database, null);
        }

        public override async void OnResume()
        {
            base.OnResume();
            DrawerActivity.SetDrawersEnabled(true);
            Toolbar.Show();

            btnLocations.Click += OnButtonClicked;

            await placeInfoSL.InitializeScreen(ReceivedParam);
        }

        public override void OnPause()
        {
            base.OnPause();

            btnLocations.Click -= OnButtonClicked;
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Id)
            {
                case Resource.Id.btn_place_locations:
                    placeInfoSL.HandleButtonLocationsClicked(ReceivedParam, new LocationListFragment());
                    break;
            }
        }

        public override TravelPlace ReceiveParamObject(Bundle param, string tag)
        {
            if (param != null)
            {
                string paramString = param.GetString(tag, "");
                if (!string.IsNullOrEmpty(paramString))
                {
                    var paramObject = JsonConvert.DeserializeObject<TravelPlace>(paramString);
                    return paramObject;
                }
            }
            return null;
        }

        public IControl GetControlByTag(string tag)
        {
            switch (tag)
            {
                case PlaceInfoScreenConst.ControlImagePlaceCover:
                    return ivPlaceCover;
                case PlaceInfoScreenConst.ControlLabelPlaceName:
                    return lblPlaceName;
                case PlaceInfoScreenConst.ControlLabelPlaceSubname:
                    return lblPlaceSubname;
                case PlaceInfoScreenConst.ControlLabelPlaceDescription:
                    return lblPlaceDescription;
                case PlaceInfoScreenConst.ControlLabelPlaceRating:
                    return lblPlaceRating;
                case PlaceInfoScreenConst.ControlLabelTravelerCount:
                    return lblTravelerCount;
                case PlaceInfoScreenConst.ControlButtonLocations:
                    return btnLocations;
            }
            return null;
        }
    }
}

