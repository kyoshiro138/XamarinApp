using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Text;
using Android.Graphics.Drawables;
using Android.OS;

namespace Xamarin.Core.Android
{
    public class SinglelineTextField : RelativeLayout, ITextField
    {
        private const int StateNormal = 0;
        private const int StateDisable = 1;
        private const int StateFocused = 2;
        private const int StateError = 3;

        private ResourceUtil ResUtil;
        private PixelConverter PixelConverter;
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
                    ChangeColorByState(StateNormal);
                }
                else
                {
                    ChangeColorByState(StateDisable);
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
                    if (string.IsNullOrEmpty(value))
                    {
                        if (!InputView.IsFocused && Enabled)
                        {
                            ChangeColorByState(StateNormal);
                            if (!string.IsNullOrEmpty(Helper))
                            {
                                Helper = HelperView.Text;    
                            }
                        }
                    }
                    else
                    {
                        ChangeColorByState(StateError);
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

        public InputType InputType
        {
            set
            {
                if (InputView != null)
                {
                    switch (value)
                    {
                        case InputType.Text:
                            InputView.InputType = InputTypes.ClassText;
                            break;
                        case InputType.TextEmail:
                            InputView.InputType = InputTypes.ClassText | InputTypes.TextVariationEmailAddress;
                            break;
                        case InputType.TextPassword:
                            InputView.InputType = InputTypes.ClassText | InputTypes.TextVariationPassword;
                            break;
                        case InputType.Number:
                            InputView.InputType = InputTypes.ClassNumber;
                            break;
                    }
                }
            }
        }

        public SinglelineTextField(Context context)
            : base(context)
        {
            InitTextField(context);
        }

        public SinglelineTextField(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitTextField(context, attrs);
        }

        public SinglelineTextField(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            InitTextField(context, attrs);
        }

        protected virtual void InitTextField(Context context, IAttributeSet attrs = null)
        {
            Inflate(context, TextFieldLayoutResId, this);
            ResUtil = new ResourceUtil(context);
            PixelConverter = new PixelConverter(context);

            InputView = FindViewById<EditText>(Resource.Id.text_field_input);
            LabelView = FindViewById<TextView>(Resource.Id.text_field_label);
            ErrorView = FindViewById<TextView>(Resource.Id.text_field_error);
            HelperView = FindViewById<TextView>(Resource.Id.text_field_helper);

            DividerView = FindViewById(Resource.Id.text_field_divider);

            InputView.SetSingleLine(true);
            InputView.FocusChange += OnFocusChanged;
            InputView.TextChanged += OnTextChanged;

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
                    ChangeColorByState(StateFocused);
                }
                else
                {
                    ChangeColorByState(StateNormal);
                }
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputView.IsFocused)
            {
                ChangeColorByState(StateFocused);
            }
            else
            {
                ChangeColorByState(StateNormal);
            }
            Error = string.Empty;
        }

        private void ChangeColorByState(int state)
        {
            switch (state)
            {
                case StateNormal:
                    if (!string.IsNullOrEmpty(Label))
                    {
                        LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColor));
                    }
                    InputView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextColor));
                    DividerView.SetBackgroundResource(0);
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
                    }
                    else
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
                        var drawable = DividerView.Background as GradientDrawable;
                        drawable.SetColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialDividerColor).DefaultColor);
                    }
                    break;
                case StateDisable:
                    if (!string.IsNullOrEmpty(Label))
                    {
                        LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColor));
                    }
                    InputView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextDisabledColor));
                    DividerView.SetBackgroundResource(0);
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_disabled);
                    }
                    else
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
                        var drawable = DividerView.Background as GradientDrawable;
                        drawable.SetColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialDividerColor).DefaultColor);
                    }
                    break;
                case StateFocused:
                    if (!string.IsNullOrEmpty(Label))
                    {
                        LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColorPrimary));
                    }
                    DividerView.SetBackgroundResource(0);
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_focused);
                    }
                    else
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
                        var drawable = DividerView.Background as GradientDrawable;
                        drawable.SetColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColorPrimary).DefaultColor);
                    }
                    break;
                case StateError:
                    if (!string.IsNullOrEmpty(Label))
                    {
                        LabelView.SetTextColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColorError));
                    }
                    DividerView.SetBackgroundResource(0);
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_error);
                    }
                    else
                    {
                        DividerView.SetBackgroundResource(Resource.Drawable.bg_text_field_divider_default);
                        var drawable = DividerView.Background as GradientDrawable;
                        drawable.SetColor(ResUtil.GetColorFromAttribute(Resource.Attribute.MaterialTextFieldLabelColorError).DefaultColor);
                    }
                    break;
            }
        }
    }
}

