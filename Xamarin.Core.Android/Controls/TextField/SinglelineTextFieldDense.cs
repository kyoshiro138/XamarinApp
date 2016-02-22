using Android.Content;
using Android.Util;

namespace Xamarin.Core.Android
{
    public class SinglelineTextFieldDense : SinglelineTextField
    {
        protected override int TextFieldLayoutResId
        {
            get { return Resource.Layout.control_text_field_singleline_dense; }
        }

        public SinglelineTextFieldDense(Context context)
            : base(context)
        {
        }

        public SinglelineTextFieldDense(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public SinglelineTextFieldDense(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }
    }
}

