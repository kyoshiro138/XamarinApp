using System;
using Android.Widget;
using Android.Views;
using Android.Util;
using Android.Content;

namespace Xamarin.Core.Android
{
    public class SystemImageView : BaseImageView
    {
        public SystemImageView(Context context)
            : base(context)
        {
        }

        public SystemImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public SystemImageView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        protected override void InitImageView(Context context, IAttributeSet attrs = null)
        {
            
        }
    }
}

