using Android.Content;
using Android.Util;
using Android.Widget;
using Android.Views;

namespace Xamarin.Core.Android
{
    public abstract class BaseButton : Button, IButton
    {
        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible) ? true : false; }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        protected BaseButton(Context context)
            : base(context)
        {
            InitButton(context);
        }

        protected BaseButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitButton(context, attrs);
        }

        protected BaseButton(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitButton(context, attrs);
        }

        protected abstract void InitButton(Context context, IAttributeSet attrs = null);
    }
}

