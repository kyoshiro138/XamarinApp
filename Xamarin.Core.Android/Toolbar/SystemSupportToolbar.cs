using Android.Support.V7.Widget;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class SystemSupportToolbar : Toolbar, IToolbar
    {
        public SystemSupportToolbar(Context context)
            : base(context)
        {
        }

        public SystemSupportToolbar(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public SystemSupportToolbar(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        public void Show()
        {
            Visibility = ViewStates.Visible;
        }

        public void Hide()
        {
            Visibility = ViewStates.Gone;
        }
    }
}

