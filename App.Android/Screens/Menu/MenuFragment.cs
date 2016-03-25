using Android.Views;
using Xamarin.Core.Android;
using Xamarin.Core;
using App.Shared;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Util;
using Android.Content;

namespace App.Android
{
    public class MenuFragment : AppFragment, IMenuScreen
    {
        private SystemLabel lblUserEmail;
        private SystemLabel lblUserName;
        private SystemListView menuList;
        private MenuScreenLogic menuSL;
        private DialogBuilder dialogBuilder;

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
            dialogBuilder = new DialogBuilder(Context);

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

        private void MenuItemClick(object sender, global::Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            MenuListAdapter adapter = menuList.Adapter as MenuListAdapter;
            if (adapter != null)
            {
                MenuItem item = adapter.DataSource[e.Position];
                switch(item.MenuId) {
                    case MenuScreenConst.MenuSettings:
                        break;
                    case MenuScreenConst.MenuSignOut:
                        menuSL.ShowSignOutConfirmationDialog();
                        break;
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

        public IDialog BuildSignOutConfirmationDialog()
        {
            var dialog = dialogBuilder.BuildSystemAlertDialog(MenuScreenConst.DialogSignOutConfirmation, string.Empty, MenuScreenConst.StringSignOutConfirmation) as SystemAlertDialog;
            dialog.SetButton((int)DialogButtonType.Positive, CommonScreenConst.StringButtonYes);
            dialog.SetButton((int)DialogButtonType.Negative, CommonScreenConst.StringButtonNo);
            dialog.OnButtonClicked += Dialog_OnButtonClicked;

            return dialog;
        }

        private async void Dialog_OnButtonClicked(object sender, OnDialogButtonClickEventArgs e)
        {
            if(e.DialogTag == MenuScreenConst.DialogSignOutConfirmation && e.ButtonId == (int)DialogButtonType.Positive) {
                await menuSL.SignOut();
                menuSL.NavigateToLogin(new LoginFragment());
            }
        }
    }
}

