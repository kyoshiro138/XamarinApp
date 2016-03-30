using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Util;

namespace Xamarin.Core.Android
{
    public abstract class BaseImageView: ImageView, IImageView
    {
        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        protected BaseImageView(Context context)
            : base(context)
        {
            InitImageView(context);
        }

        protected BaseImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitImageView(context, attrs);
        }

        protected BaseImageView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            InitImageView(context, attrs);
        }

        protected abstract void InitImageView(Context context, IAttributeSet attrs = null);
    }
}

