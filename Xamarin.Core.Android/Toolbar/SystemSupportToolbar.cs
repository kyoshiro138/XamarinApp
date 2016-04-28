using Android.Support.V7.Widget;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class SystemSupportToolbar : Toolbar, IToolbar
    {
        string IToolbar.NavigationIcon
        {
            set
            {
                if (!string.IsNullOrEmpty(value) && Context != null)
                {
                    int resId = Resources.GetIdentifier(value, "drawable", Context.PackageName);
                    SetNavigationIcon(resId);
                }
            }
        }

        public SystemSupportToolbar(Context context)
            : base(context)
        {
            InitToolbar(context);
        }

        public SystemSupportToolbar(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitToolbar(context);
        }

        public SystemSupportToolbar(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitToolbar(context);
        }

        private void InitToolbar(Context context)
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

