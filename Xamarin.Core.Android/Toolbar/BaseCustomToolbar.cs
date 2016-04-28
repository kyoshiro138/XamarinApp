using Android.Widget;
using Android.Util;
using Android.Content;
using Android.Views;
using System;
using Android.Runtime;

namespace Xamarin.Core.Android
{
    public abstract class BaseCustomToolbar : RelativeLayout, IToolbar
    {
        protected abstract int ToolbarLayoutResourceId { get; }

        public abstract string Title { get; set; }

        public abstract string NavigationIcon { set; }

        protected BaseCustomToolbar(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        protected BaseCustomToolbar(Context context)
            : base(context)
        {
            InitToolbar(context);
        }

        protected BaseCustomToolbar(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitToolbar(context);
        }

        protected BaseCustomToolbar(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitToolbar(context);
        }

        private void InitToolbar(Context context)
        {
            Inflate(context, ToolbarLayoutResourceId, this);
            BindToolbarControls();
        }

        protected abstract void BindToolbarControls();

        public void Show()
        {
            Visibility = ViewStates.Visible;
        }

        public void Hide()
        {
            Visibility = ViewStates.Gone;
        }
    }
}

