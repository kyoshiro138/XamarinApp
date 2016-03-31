using Android.Content;
using App.Shared;
using Xamarin.Core.Android;
using Android.Graphics;
using Android.Util;

namespace App.Android
{
    public class PlaceItemView : BaseGridItemView<TravelPlace>
    {
        protected override int GridItemLayoutResId
        {
            get { return Resource.Layout.grid_place_item; }
        }

        private SystemLabel lblPlaceName;
        private FFImageLoadingView ivPlaceCover;

        public PlaceItemView(Context context)
            : base(context)
        {
        }

        protected override void BindControls()
        {
            base.BindControls();

            lblPlaceName = FindViewById<SystemLabel>(Resource.Id.lbl_place_name);
            lblPlaceName.SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Bold);
            lblPlaceName.SetTextSize(ComplexUnitType.Sp, 16f);
            lblPlaceName.SetTextColor(Resources.GetColor(Resource.Color.c_text_white));

            ivPlaceCover = FindViewById<FFImageLoadingView>(Resource.Id.iv_place_image);
            ivPlaceCover.DefaultPlaceHolderPath = "Images/img_place_holder.png";
        }

        public override void LoadItemData(TravelPlace data)
        {
            base.LoadItemData(data);

            lblPlaceName.Text = data.PlaceName;
            ivPlaceCover.LoadImageFromUrl(data.PlaceCoverUrl);
        }
    }
}

