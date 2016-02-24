using Xamarin.Core.Android;
using App.Shared;
using Android.Content;

namespace App.Android
{
    public class LocationItemView : BaseListItemView<PlaceLocation>
    {
        private MaterialLabel lblTitle;
        private MaterialLabel lblDescription;
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

            lblTitle = FindViewById<MaterialLabel>(Resource.Id.lbl_location_title);
            lblDescription = FindViewById<MaterialLabel>(Resource.Id.lbl_location_description);
            btnDetail = FindViewById<SystemButton>(Resource.Id.btn_location_detail);
            btnMap = FindViewById<SystemButton>(Resource.Id.btn_location_map);

            lblTitle.ApplyTextFontAndSizeByType(MaterialLabelType.Title);
            lblDescription.ApplyTextFontAndSizeByType(MaterialLabelType.Body1);
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

