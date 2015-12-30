﻿using System;
using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class SystemButton : Button, IButton
    {
        public bool IsVisible
        {
            get
            {
                return (Visibility == ViewStates.Visible) ? true : false;
            }
            set
            {
                Visibility = (value ? ViewStates.Visible : ViewStates.Gone);
            }
        }

        public SystemButton(Context context)
            : base(context)
        {
        }

        public SystemButton(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public SystemButton(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }
    }
}
