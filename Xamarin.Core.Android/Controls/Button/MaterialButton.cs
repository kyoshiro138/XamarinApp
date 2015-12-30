using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Graphics;

namespace Xamarin.Core.Android
{
    public class MaterialButton : Button, IButton
    {
        private const string FONT_PATH = "Fonts/roboto_medium.ttf";
        private const float FONT_SIZE = 14f;

        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        public MaterialButton(Context context)
            : base(context)
        {
            InitView(context);
        }

        public MaterialButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitView(context, attrs);
        }

        public MaterialButton(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitView(context, attrs);
        }

        private void InitView(Context context, IAttributeSet attrs = null)
        {
            if (attrs != null)
            {
                // TODO: set custom style for material button
            }

            SetTypeface(FontUtil.LoadFont(context, FONT_PATH), TypefaceStyle.Normal);
            SetTextSize(ComplexUnitType.Sp, FONT_SIZE);
            SetAllCaps(true);
        }
    }
}

