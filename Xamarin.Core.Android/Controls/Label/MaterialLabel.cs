using System;
using Android.Content;
using Android.Util;
using Android.Graphics;

namespace Xamarin.Core.Android
{
    public class MaterialLabel : SystemLabel
    {
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
            ApplyTextFontAndSizeByType(MaterialLabelType.UnSpecified);
        }

        public void ApplyTextFontAndSizeByType(MaterialLabelType labelType)
        {
            switch (labelType)
            {
                case MaterialLabelType.Caption:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Caption);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Body1:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Body1);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Body2:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Body2);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoMedium), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Subhead:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Subhead);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Title:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Title);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoMedium), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Headline:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Headline);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Display1:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Display1);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Display2:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Display2);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Display3:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Display3);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.Display4:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Display4);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoLight), TypefaceStyle.Normal);
                    break;
                case MaterialLabelType.UnSpecified:
                    SetTextAppearance(Context, Resource.Style.TextAppearance_AppCompat_Body1);
                    SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
                    break;
            }
        }
    }
}

