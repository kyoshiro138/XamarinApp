using Android.Content;
using App.Shared;
using Xamarin.Core.Android;
using Android.Graphics;

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
            lblPlaceName.SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular), global::Android.Graphics.TypefaceStyle.Bold);
            lblPlaceName.SetTextSize(global::Android.Util.ComplexUnitType.Sp, 16f);
            lblPlaceName.SetTextColor(Color.White);
        }

        public override void LoadItemData(TravelPlace data)
        {
            base.LoadItemData(data);

            lblPlaceName.Text = data.PlaceName;
        }
    }
}

