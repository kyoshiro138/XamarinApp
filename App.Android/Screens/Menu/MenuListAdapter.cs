using System;
using Xamarin.Core.Android;
using App.Shared;
using Android.Content;
using System.Collections.Generic;

namespace App.Android
{
    public class MenuListAdapter : BaseListAdapter<MenuItemView,MenuItem>
    {
        public MenuListAdapter(Context context, List<MenuItem> data)
            : base(context, data)
        {
        }
    }
}

