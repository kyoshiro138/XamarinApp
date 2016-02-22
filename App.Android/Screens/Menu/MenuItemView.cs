using System;
using Xamarin.Core.Android;
using App.Shared;
using Android.Content;
using Android.Widget;
using Android.Graphics;

namespace App.Android
{
    public class MenuItemView : BaseListItemView<MenuItem>
    {
        private ImageView imgIcon;
        private TextView txtTitle;

        protected override int ListItemLayoutResId
        {
            get { return Resource.Layout.list_item_signle_line; }
        }

        public MenuItemView(Context context)
            : base(context)
        {
        }

        protected override void BindControls()
        {
            base.BindControls();

            imgIcon = FindViewById<ImageView>(Resource.Id.list_item_single_line_image);
            txtTitle = FindViewById<TextView>(Resource.Id.list_item_single_line_text);
        }

        public override void LoadItemData(MenuItem data)
        {
            base.LoadItemData(data);
            switch (data.MenuId)
            {
                case MenuScreenConst.MenuSignOut:
                    imgIcon.SetBackgroundColor(Color.Red);
                    break;
                case MenuScreenConst.MenuSettings:
                    imgIcon.Visibility = global::Android.Views.ViewStates.Gone;
                    break;
            }
            txtTitle.Text = data.MenuTitle;
        }
    }
}

