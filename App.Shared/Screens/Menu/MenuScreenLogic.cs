using System;
using Xamarin.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Shared
{
    public class MenuScreenLogic
    {
        private readonly IMenuScreen menuScreen;

        public MenuScreenLogic(IMenuScreen screen)
        {
            menuScreen = screen;
        }

        public async Task LoadMenu()
        {
            User currentUser = await menuScreen.UserManager.GetCurrentUser();
            List<MenuItem> menuList = new List<MenuItem>();
            if (currentUser.UserId == 1)
            {
                // Menu for member
                menuList.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSettings, MenuId = MenuScreenConst.MenuSettings });
                menuList.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSignOut, MenuId = MenuScreenConst.MenuSignOut });
            }
            else
            {
                // Menu for guest
                menuList.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSettings, MenuId = MenuScreenConst.MenuSettings });
                menuList.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSignOut, MenuId = MenuScreenConst.MenuSignOut });
            }

            IListView menuListView = menuScreen.GetControlByTag(MenuScreenConst.ControlListMenu) as IListView;
            menuListView.SetDataSource(menuScreen.GetMenuListDataSource(menuList));
        }

        public async Task SignOut()
        {
            await menuScreen.UserManager.RemoveUserAuthentication();
        }

        public void NavigateToLogin(IScreen loginScreen)
        {
            menuScreen.Navigator.NavigateTo(loginScreen, true);
        }
    }
}

