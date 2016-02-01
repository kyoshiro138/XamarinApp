using Android.Content;
using Android.Util;

namespace Xamarin.Core.Android
{
    public class SinglelineTextFieldDense : SinglelineTextField
    {
        private const float INPUT_FONT_SIZE = 13f;
        private const float LABEL_FONT_SIZE = 13f;
        private const float ERROR_FONT_SIZE = 12f;
        private const float HELPER_FONT_SIZE = 12f;

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

        protected override void InitTextField(Context context, IAttributeSet attrs = null)
        {
            base.InitTextField(context);

            InputView.SetTextSize(ComplexUnitType.Sp, INPUT_FONT_SIZE);
            LabelView.SetTextSize(ComplexUnitType.Sp, LABEL_FONT_SIZE);
            ErrorView.SetTextSize(ComplexUnitType.Sp, ERROR_FONT_SIZE);
            HelperView.SetTextSize(ComplexUnitType.Sp, HELPER_FONT_SIZE);
        }
    }
}

