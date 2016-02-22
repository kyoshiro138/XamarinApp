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
        }

        public override void LoadItemData(TravelPlace data)
        {
            base.LoadItemData(data);

            lblPlaceName.Text = data.PlaceName;
        }
    }
}

