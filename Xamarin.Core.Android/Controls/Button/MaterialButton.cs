using Android.Content;
using Android.Util;
using Android.OS;
using Android.Graphics;

namespace Xamarin.Core.Android
{
    public class MaterialButton : SystemButton
    {
        public MaterialButton(Context context)
            : base(context, null, Resource.Style.Widget_AppCompat_Button)
        {
        }

        public MaterialButton(Context context, IAttributeSet attrs)
            : base(context, attrs, Resource.Style.Widget_AppCompat_Button)
        {
        }

        public MaterialButton(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void InitButton(Context context, IAttributeSet attrs = null)
        {
            base.InitButton(context, attrs);

            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
            {
                PixelConverter converter = new PixelConverter(context);

                SetTextAppearance(context, Resource.Style.TextAppearance_AppCompat_Button);
                SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                SetMinimumWidth((int)converter.FromDp(88));
            }
        }
    }
}

