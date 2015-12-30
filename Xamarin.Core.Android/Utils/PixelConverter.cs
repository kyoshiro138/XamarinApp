using Android.Content;
using Android.Util;

namespace Xamarin.Core.Android
{
    public class PixelConverter
    {
        private readonly Context context;

        public PixelConverter(Context context)
        {
            this.context = context;
        }

        public float FromDp(float dp)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, context.Resources.DisplayMetrics);
        }

        public float FromSp(float sp)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Sp, sp, context.Resources.DisplayMetrics);
        }
    }
}

