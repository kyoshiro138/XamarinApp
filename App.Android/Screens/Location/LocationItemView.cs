using System;
using Xamarin.Core.Android;
using App.Shared;
using Android.Content;
using Android.Graphics;
using Android.Util;

namespace App.Android
{
    public class LocationItemView : BaseListItemView<PlaceLocation>
    {
        private SystemLabel lblTitle;
        private SystemLabel lblDescription;
        private SystemButton btnDetail;
        private SystemButton btnMap;

        protected override int ListItemLayoutResId
        {
            get { return Resource.Layout.list_location_item; }
        }

        public LocationItemView(Context context)
            : base(context)
        {
        }

        protected override void BindControls()
        {
            base.BindControls();

            lblTitle = FindViewById<SystemLabel>(Resource.Id.lbl_location_title);
            lblDescription = FindViewById<SystemLabel>(Resource.Id.lbl_location_description);
            btnDetail = FindViewById<SystemButton>(Resource.Id.btn_location_detail);
            btnMap = FindViewById<SystemButton>(Resource.Id.btn_location_map);
        }

        public override void LoadItemData(PlaceLocation data)
        {
            base.LoadItemData(data);

            lblTitle.Text = data.LocationName;
            lblDescription.Text = data.LocationName;
            btnDetail.Text = LocationListScreenConst.StringButtonDetails;
            btnMap.Text = LocationListScreenConst.StringButtonMap;
        }
    }
}

