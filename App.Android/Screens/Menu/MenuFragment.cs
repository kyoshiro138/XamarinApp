using Android.Views;
using Xamarin.Core.Android;
using Xamarin.Core;
using App.Shared;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace App.Android
{
    public class MenuFragment : AppFragment, IMenuScreen
    {
        private XamarinListView menuList;
        private MenuScreenLogic menuSL;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_menu; }
        }

        public UserManager UserManager { get; private set; }

        protected override void BindControls(View rootView)
        {
            menuList = rootView.FindViewById<XamarinListView>(Resource.Id.list_menu);
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
                    case MenuScreenConst.ControlListView:
                        return menuList;
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

