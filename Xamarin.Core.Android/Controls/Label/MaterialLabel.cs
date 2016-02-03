using System;
using Android.Content;
using Android.Util;
using Android.Graphics;

namespace Xamarin.Core.Android
{
    public class MaterialLabel : SystemLabel
    {
        private const int DisplayTypeDisplay4 = 1;
        private const int DisplayTypeDisplay3 = 2;
        private const int DisplayTypeDisplay2 = 3;
        private const int DisplayTypeDisplay1 = 4;
        private const int DisplayTypeHeadline = 5;
        private const int DisplayTypeTitle = 6;
        private const int DisplayTypeSubhead = 7;
        private const int DisplayTypeBody2 = 8;
        private const int DisplayTypeBody1 = 9;
        private const int DisplayTypeCaption = 10;

        private const int FontTypeRobotoLight = 1;
        private const int FontTypeRobotoRegular = 2;
        private const int FontTypeRobotoMedium = 3;

        public MaterialLabel(Context context)
            : base(context)
        {
        }

        public MaterialLabel(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public MaterialLabel(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void InitLabel(Context context, IAttributeSet attrs = null)
        {
            base.InitLabel(context, attrs);
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
                case DisplayTypeDisplay4:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedLight);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoLight);
                    }
                case DisplayTypeDisplay3:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
                case DisplayTypeDisplay2:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
                case DisplayTypeDisplay1:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
                case DisplayTypeHeadline:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
                case DisplayTypeTitle:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular, TypefaceStyle.Bold);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoMedium);
                    }
                case DisplayTypeSubhead:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
                case DisplayTypeBody2:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular, TypefaceStyle.Bold);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoMedium);
                    }
                case DisplayTypeBody1:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
                case DisplayTypeCaption:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
                default:
                    if (IsCondensed)
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoCondensedRegular);
                    }
                    else
                    {
                        return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                    }
            }
        }

        private float getFontSizeByDisplayType(int displayType)
        {
            switch (displayType)
            {
                case DisplayTypeDisplay4:
                    return 112f;
                case DisplayTypeDisplay3:
                    return 56f;
                case DisplayTypeDisplay2:
                    return 45f;
                case DisplayTypeDisplay1:
                    return 34f;
                case DisplayTypeHeadline:
                    return 24f;
                case DisplayTypeTitle:
                    return 20f;
                case DisplayTypeSubhead:
                    return 16f;
                case DisplayTypeBody2:
                    return 14f;
                case DisplayTypeBody1:
                    return 14f;
                case DisplayTypeCaption:
                    return 12f;
                default:
                    return 14f;
            }
        }

        private Typeface getFont(int fontType)
        {
            switch (fontType)
            {
                case FontTypeRobotoLight:
                    return FontUtil.LoadSystemFont(FontUtil.FontRobotoLight);
                case FontTypeRobotoRegular:
                    return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
                case FontTypeRobotoMedium:
                    return FontUtil.LoadSystemFont(FontUtil.FontRobotoMedium);
                default:
                    return FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular);
            }
        }
    }
}

