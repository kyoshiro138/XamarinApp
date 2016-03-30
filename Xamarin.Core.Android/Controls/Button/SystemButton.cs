using Android.Content;
using Android.Util;

namespace Xamarin.Core.Android
{
    public class SystemButton : BaseButton
    {
        public SystemButton(Context context)
            : base(context)
        {
        }

        public SystemButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public SystemButton(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void InitButton(Context context, IAttributeSet attrs = null)
        {
        }
    }
}

