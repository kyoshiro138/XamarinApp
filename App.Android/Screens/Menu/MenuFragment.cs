using Android.Views;
using Xamarin.Core.Android;
using Xamarin.Core;
using App.Shared;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Util;

namespace App.Android
{
    public class MenuFragment : AppFragment, IMenuScreen
    {
        private SystemLabel lblUserEmail;
        private SystemLabel lblUserName;
        private SystemListView menuList;
        private MenuScreenLogic menuSL;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_menu; }
        }

        protected override void BindControls(View rootView)
        {
            lblUserEmail = rootView.FindViewById<SystemLabel>(Resource.Id.lbl_menu_user_email);
            lblUserName = rootView.FindViewById<SystemLabel>(Resource.Id.lbl_menu_user_name);
            menuList = rootView.FindViewById<SystemListView>(Resource.Id.list_menu);

            lblUserEmail.SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoRegular), TypefaceStyle.Normal);
            lblUserEmail.SetTextSize(ComplexUnitType.Sp, 14);
            lblUserName.SetTypeface(FontUtil.LoadSystemFont(FontUtil.FontRobotoMedium), TypefaceStyle.Bold);
            lblUserName.SetTextSize(ComplexUnitType.Sp, 14);
        }

        protected override void LoadData()
        {
            var database = new AppAndroidDatabaseManager(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            var appPref = new ApplicationPreferences();

            UserManager = new UserManager(null, database, appPref);

            menuSL = new MenuScreenLogic(this);
        }

        public IControl GetControlByTag(string tag)
        {
            if (View != null)
            {
                switch (tag)
                {
                    case MenuScreenConst.ControlListMenu:
                        return menuList;
                    case MenuScreenConst.ControlLabelUserEmail:
                        return lblUserEmail;
                    case MenuScreenConst.ControlLabelUserName:
                        return lblUserName;
                    default:
                        return null;
                }
            }
            return null;
        }

        public override void OnResume()
        {
            base.OnResume();

            menuList.ItemClick += MenuItemClick;
        }

        public override void OnPause()
        {
            base.OnPause();

            menuList.ItemClick -= MenuItemClick;
        }

        private async void MenuItemClick(object sender, global::Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            MenuListAdapter adapter = menuList.Adapter as MenuListAdapter;
            if (adapter != null)
            {
                MenuItem item = adapter.DataSource[e.Position];
                if (item.MenuId.Equals(MenuScreenConst.MenuSignOut))
                {
                    await menuSL.SignOut();
                    menuSL.NavigateToLogin(new LoginFragment());
                }
            }
        }

        public IListDataSource<MenuItem> GetMenuListDataSource(List<MenuItem> data)
        {
            var adapter = new MenuListAdapter(Context, data);
            return adapter;
        }

        public async Task LoadMenu()
        {
            await menuSL.LoadMenu();
        }
    }
}

