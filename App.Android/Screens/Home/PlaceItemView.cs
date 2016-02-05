using Android.Content;
using App.Shared;
using Xamarin.Core.Android;
using Android.Graphics;
using Android.Util;

namespace App.Android
{
    public class PlaceItemView : BaseGridItemView<TravelPlace>
    {
        private SystemLabel lblPlaceName;

        public PlaceItemView(Context context)
            : base(context)
        {
        }

        protected override void InflateItemView(Context context)
        {
            Inflate(context, Resource.Layout.grid_place_item, this);

            lblPlaceName = FindViewById<SystemLabel>(Resource.Id.lbl_place_name);
            lblPlaceName.SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular), TypefaceStyle.Bold);
            lblPlaceName.SetTextSize(ComplexUnitType.Sp, 16f);
        }

        public override void LoadItemData(TravelPlace data)
        {
            base.LoadItemData(data);

            lblPlaceName.Text = data.PlaceName;
        }
    }
}

