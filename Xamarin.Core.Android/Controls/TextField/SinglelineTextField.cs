using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Graphics;
using Android.Text;

namespace Xamarin.Core.Android
{
    public class SinglelineTextField : RelativeLayout, ITextField
    {
        private const float INPUT_FONT_SIZE = 16f;
        private const float LABEL_FONT_SIZE = 12f;
        private const float ERROR_FONT_SIZE = 12f;
        private const float HELPER_FONT_SIZE = 12f;

        private const string FONT_PATH = "Fonts/roboto_regular.ttf";

        private ResourceUtil ResUtil;
        private View DividerView;

        protected EditText InputView { get; private set; }

        protected TextView LabelView { get; private set; }

        protected TextView ErrorView { get; private set; }

        protected TextView HelperView { get; private set; }

        protected virtual int TextFieldLayoutResId
        {
            get { return Resource.Layout.control_text_field_singleline; }
        }

        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        public override bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                InputView.Enabled = value;
                if (InputView.IsFocused)
                {
                    InputView.ClearFocus();
                }

                if (value)
                {
                    DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
                    InputView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextColor));
                }
                else
                {
                    DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_disabled);
                    InputView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextDisabledColor));
                    LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColor));
                    Error = string.Empty;
                }
            }
        }

        public string Input
        {
            get { return InputView.Text; }
            set { InputView.Text = value; }
        }

        public string Hint
        {
            get { return InputView.Hint; }
            set { InputView.Hint = value; }
        }

        public string Label
        {
            get { return LabelView.Text; }
            set
            {
                LabelView.Visibility = string.IsNullOrEmpty(value) ? ViewStates.Gone : ViewStates.Visible;
                LabelView.Text = value;
            }
        }

        public string Helper
        {
            get { return HelperView.Text; }
            set
            {
                if (ErrorView.Visibility != ViewStates.Visible)
                {
                    HelperView.Visibility = string.IsNullOrEmpty(value) ? ViewStates.Gone : ViewStates.Visible;
                }
                HelperView.Text = value;
            }
        }

        public string Error
        {
            get { return ErrorView.Text; }
            set
            { 
                if (ErrorEnabled)
                {
                    ErrorView.Visibility = string.IsNullOrEmpty(value) ? ViewStates.Invisible : ViewStates.Visible;
                    if (string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(Helper))
                    {
                        Helper = HelperView.Text;
                    }
                }
                ErrorView.Text = value;
            }
        }

        public bool ErrorEnabled
        {
            get { return ErrorView.Visibility != ViewStates.Gone; }
            set
            { 
                if (value)
                {
                    ErrorView.Visibility = ViewStates.Invisible;
                    Error = ErrorView.Text;
                }
                else
                {
                    ErrorView.Visibility = ViewStates.Gone;
                    Error = "";
                    if (!string.IsNullOrEmpty(Helper))
                    {
                        Helper = HelperView.Text;
                    }
                }
            }
        }

        public override bool IsFocused
        {
            get { return base.IsFocused || InputView.IsFocused; }
        }

        public SinglelineTextField(Context context)
            : base(context)
        {
            Initialize(context);
        }

        public SinglelineTextField(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize(context);
        }

        public SinglelineTextField(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            Initialize(context);
        }

        protected virtual void Initialize(Context context)
        {
            Inflate(context, TextFieldLayoutResId, this);
            ResUtil = new ResourceUtil(context);

            InputView = FindViewById<EditText>(Resource.Id.text_field_input);
            LabelView = FindViewById<TextView>(Resource.Id.text_field_label);
            ErrorView = FindViewById<TextView>(Resource.Id.text_field_error);
            HelperView = FindViewById<TextView>(Resource.Id.text_field_helper);

            DividerView = FindViewById(Resource.Id.text_field_divider);

            InputView.SetTypeface(FontUtil.LoadFont(context, FONT_PATH), TypefaceStyle.Normal);
            InputView.SetTextSize(ComplexUnitType.Sp, INPUT_FONT_SIZE);
            InputView.FocusChange += OnFocusChanged;
            InputView.TextChanged += OnTextChanged;

            LabelView.SetTypeface(FontUtil.LoadFont(context, FONT_PATH), TypefaceStyle.Normal);
            LabelView.SetTextSize(ComplexUnitType.Sp, LABEL_FONT_SIZE);

            ErrorView.SetTypeface(FontUtil.LoadFont(context, FONT_PATH), TypefaceStyle.Normal);
            ErrorView.SetTextSize(ComplexUnitType.Sp, ERROR_FONT_SIZE);

            HelperView.SetTypeface(FontUtil.LoadFont(context, FONT_PATH), TypefaceStyle.Normal);
            HelperView.SetTextSize(ComplexUnitType.Sp, HELPER_FONT_SIZE);

            Enabled = true;
        }

        public override void ClearFocus()
        {
            base.ClearFocus();
            if (InputView.IsFocused)
            {
                InputView.ClearFocus();
            }
        }

        private void OnFocusChanged(object sender, FocusChangeEventArgs e)
        {
            if (ErrorView.Visibility != ViewStates.Visible)
            {
                if (e.HasFocus)
                {
                    if (!string.IsNullOrEmpty(Label))
                    {
                        LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColorPrimary));
                    }
                    DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_focused);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Label))
                    {
                        LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColor));
                    }
                    DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
                }
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputView.IsFocused)
            {
                if (!string.IsNullOrEmpty(Label))
                {
                    LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColorPrimary));
                }
                DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_focused);
            }
            else
            {
                if (!string.IsNullOrEmpty(Label))
                {
                    LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColor));
                }
                DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
            }
            Error = string.Empty;
        }
    }
}

