using System;
using Xamarin.Core.Android;
using Android.Content;
using Android.Util;
using Android.Widget;

namespace App.Android
{
    public class AndroidToolbar : BaseCustomToolbar
    {
        private ImageButton btnNavigation;
        private MaterialLabel lblTitle;

        protected override int ToolbarLayoutResourceId
        {
            get { return Resource.Layout.toolbar_layout; }
        }

        public override string Title
        {
            get
            {
                if (lblTitle != null)
                {
                    return lblTitle.Text;
                }
                return "";
            }
            set
            {
                if (lblTitle != null)
                {
                    lblTitle.Text = value;
                }
            }
        }

        public override string NavigationIcon
        {
            set
            {
                if (!string.IsNullOrEmpty(value) && Context != null && btnNavigation != null)
                {
                    int resId = Resources.GetIdentifier(value, "drawable", Context.PackageName);
                    btnNavigation.SetImageResource(resId);
                }
            }
        }

        public AndroidToolbar(Context context)
            : base(context)
        {
        }

        public AndroidToolbar(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public AndroidToolbar(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        protected override void BindToolbarControls()
        {
            btnNavigation = FindViewById<ImageButton>(Resource.Id.btn_toolbar_navigation);
            lblTitle = FindViewById<MaterialLabel>(Resource.Id.lbl_toolbar_title);

            lblTitle.ApplyTextFontAndSizeByType(MaterialLabelType.Title);
            lblTitle.SetTextColor(Resources.GetColor(Resource.Color.c_text_white));
        }

        public void SetNavigationOnClickListener(IOnClickListener listener)
        {
            if (btnNavigation != null)
            {
                btnNavigation.SetOnClickListener(listener);
            }
        }
    }
}

