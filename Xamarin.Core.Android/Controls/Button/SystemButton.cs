using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class SystemButton : Button, IButton
    {
        protected bool IsCondensed { get; set; }

        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible) ? true : false; }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        public SystemButton(Context context)
            : base(context)
        {
            InitButton(context);
        }

        public SystemButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitButton(context, attrs);
        }

        public SystemButton(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitButton(context, attrs);
        }

        protected virtual void InitButton(Context context, IAttributeSet attrs = null)
        {
            IsCondensed = true;
            if (IsCondensed)
            {
                Typeface = FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular, global::Android.Graphics.TypefaceStyle.Bold);
            }
            else
            {
                Typeface = FontUtil.LoadSystemFont(FontUtil.FontRobotoMedium);
            }
        }
    }
}

