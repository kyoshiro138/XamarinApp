using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class SystemLabel : TextView, ILabel
    {
        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        public SystemLabel(Context context)
            : base(context)
        {
            InitLabel(context);
        }

        public SystemLabel(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitLabel(context, attrs);
        }

        public SystemLabel(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitLabel(context, attrs);
        }

        protected virtual void InitLabel(Context context, IAttributeSet attrs = null)
        {
           
        }
    }
}

