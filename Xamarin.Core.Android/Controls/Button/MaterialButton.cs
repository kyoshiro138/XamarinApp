using Android.Content;
using Android.Util;

namespace Xamarin.Core.Android
{
    public class MaterialButton : SystemButton
    {
        private const float ButtonTextSize = 14f;

        public MaterialButton(Context context)
            : base(context)
        {
        }

        public MaterialButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public MaterialButton(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void InitButton(Context context, IAttributeSet attrs = null)
        {
            base.InitButton(context, attrs);

            if (attrs != null)
            {
                // TODO: set custom style for material button
            }

            SetTextSize(ComplexUnitType.Sp, ButtonTextSize);
            SetAllCaps(true);
        }
    }
}

