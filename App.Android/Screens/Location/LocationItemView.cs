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
        private FFImageLoadingView ivCover;

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
            lblTitle.ApplyTextFontAndSizeByType(MaterialLabelType.Title);

            lblDescription = FindViewById<MaterialLabel>(Resource.Id.lbl_location_description);
            lblDescription.ApplyTextFontAndSizeByType(MaterialLabelType.Body1);

            ivCover = FindViewById<FFImageLoadingView>(Resource.Id.iv_location_image);
            ivCover.DefaultPlaceHolderPath = "Images/img_place_holder.png";

            btnDetail = FindViewById<SystemButton>(Resource.Id.btn_location_detail);
            btnDetail.Text = LocationListScreenConst.StringButtonDetails;

            btnMap = FindViewById<SystemButton>(Resource.Id.btn_location_map);
            btnMap.Text = LocationListScreenConst.StringButtonMap;
        }

        public override void LoadItemData(PlaceLocation data)
        {
            base.LoadItemData(data);

            lblTitle.Text = data.LocationName;
            lblDescription.Text = data.LocationName;
            ivCover.LoadImageFromUrl(data.LocationCoverUrl);
        }
    }
}

