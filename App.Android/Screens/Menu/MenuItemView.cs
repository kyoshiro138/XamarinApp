using System;
using Xamarin.Core.Android;
using App.Shared;
using Android.Content;
using Android.Widget;

namespace App.Android
{
    public class MenuItemView : BaseListItemView<MenuItem>
    {
        private ImageView imgIcon;
        private TextView txtTitle;

        public MenuItemView(Context context)
            : base(context)
        {
            Inflate(context, Resource.Layout.list_menu_item, this);

            imgIcon = FindViewById<ImageView>(Resource.Id.img_menu_icon);
            txtTitle = FindViewById<TextView>(Resource.Id.tv_menu_title);
        }


        public override void LoadItemData(MenuItem data)
        {
            base.LoadItemData(data);

            txtTitle.Text = data.Title;
        }
    }
}

