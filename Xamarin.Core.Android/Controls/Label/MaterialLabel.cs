using System;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Util;
using Android.Graphics;

namespace Xamarin.Core.Android
{
    public class MaterialLabel : TextView, ILabel
    {
        private const int DISPLAY_TYPE_DISPLAY_4 = 1;
        private const int DISPLAY_TYPE_DISPLAY_3 = 2;
        private const int DISPLAY_TYPE_DISPLAY_2 = 3;
        private const int DISPLAY_TYPE_DISPLAY_1 = 4;
        private const int DISPLAY_TYPE_HEADLINE = 5;
        private const int DISPLAY_TYPE_TITLE = 6;
        private const int DISPLAY_TYPE_SUBHEAD = 7;
        private const int DISPLAY_TYPE_BODY_2 = 8;
        private const int DISPLAY_TYPE_BODY_1 = 9;
        private const int DISPLAY_TYPE_CAPTION = 10;

        private const int FONT_TYPE_ROBOTO_LIGHT = 1;
        private const int FONT_TYPE_ROBOTO_REGULAR = 2;
        private const int FONT_TYPE_ROBOTO_MEDIUM = 3;

        private const string FONT_PATH_ROBOTO_LIGHT = "Fonts/roboto_light.ttf";
        private const string FONT_PATH_ROBOTO_MEDIUM = "Fonts/roboto_medium.ttf";
        private const string FONT_PATH_ROBOTO_REGULAR = "Fonts/roboto_regular.ttf";

        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        public MaterialLabel(Context context)
            : base(context)
        {
            InitView(context);
        }

        public MaterialLabel(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitView(context, attrs);
        }

        public MaterialLabel(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitView(context, attrs);
        }

        private void InitView(Context context, IAttributeSet attrs = null)
        {
            if (attrs != null)
            {
                var styledAttributes = context.ObtainStyledAttributes(attrs, Resource.Styleable.MaterialLabel);
                var displayType = styledAttributes.GetInt(Resource.Styleable.MaterialLabel_display_type, 0);
                var fontType = styledAttributes.GetInt(Resource.Styleable.MaterialLabel_material_font, 0);
                styledAttributes.Recycle();

                if (displayType > 0)
                {
                    SetTypeface(getFontByDisplayType(displayType), TypefaceStyle.Normal);
                    SetTextSize(ComplexUnitType.Sp, getFontSizeByDisplayType(displayType));
                }
                if (fontType > 0)
                {
                    SetTypeface(getFont(fontType), TypefaceStyle.Normal);
                }
            }
        }

        private Typeface getFontByDisplayType(int displayType)
        {
            switch (displayType)
            {
                case DISPLAY_TYPE_DISPLAY_4:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_LIGHT);
                case DISPLAY_TYPE_DISPLAY_3:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                case DISPLAY_TYPE_DISPLAY_2:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                case DISPLAY_TYPE_DISPLAY_1:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                case DISPLAY_TYPE_HEADLINE:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                case DISPLAY_TYPE_TITLE:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_MEDIUM);
                case DISPLAY_TYPE_SUBHEAD:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                case DISPLAY_TYPE_BODY_2:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_MEDIUM);
                case DISPLAY_TYPE_BODY_1:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                case DISPLAY_TYPE_CAPTION:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                default:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
            }
        }

        private float getFontSizeByDisplayType(int displayType)
        {
            switch (displayType)
            {
                case DISPLAY_TYPE_DISPLAY_4:
                    return 112f;
                case DISPLAY_TYPE_DISPLAY_3:
                    return 56f;
                case DISPLAY_TYPE_DISPLAY_2:
                    return 45f;
                case DISPLAY_TYPE_DISPLAY_1:
                    return 34f;
                case DISPLAY_TYPE_HEADLINE:
                    return 24f;
                case DISPLAY_TYPE_TITLE:
                    return 20f;
                case DISPLAY_TYPE_SUBHEAD:
                    return 16f;
                case DISPLAY_TYPE_BODY_2:
                    return 14f;
                case DISPLAY_TYPE_BODY_1:
                    return 14f;
                case DISPLAY_TYPE_CAPTION:
                    return 12f;
                default:
                    return 14f;
            }
        }

        private Typeface getFont(int fontType)
        {
            switch (fontType)
            {
                case FONT_TYPE_ROBOTO_LIGHT:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_LIGHT);
                case FONT_TYPE_ROBOTO_REGULAR:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
                case FONT_TYPE_ROBOTO_MEDIUM:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_MEDIUM);
                default:
                    return FontUtil.LoadFont(Context, FONT_PATH_ROBOTO_REGULAR);
            }
        }
    }
}

