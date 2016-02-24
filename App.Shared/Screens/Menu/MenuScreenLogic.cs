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
            ILabel lblUserEmail = menuScreen.GetControlByTag(MenuScreenConst.ControlLabelUserEmail) as ILabel;
            ILabel lblUserName = menuScreen.GetControlByTag(MenuScreenConst.ControlLabelUserName) as ILabel;
            IListView listMenu = menuScreen.GetControlByTag(MenuScreenConst.ControlListMenu) as IListView;

            User currentUser = await menuScreen.UserManager.GetCurrentUser();
            List<MenuItem> listMenuItems = new List<MenuItem>();
            if (currentUser.Role == (int)User.RoleType.Member)
            {
                // Menu for member
                listMenuItems.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSettings, MenuId = MenuScreenConst.MenuSettings });
                listMenuItems.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSignOut, MenuId = MenuScreenConst.MenuSignOut });

                if (currentUser.IsEmailUsername())
                {
                    lblUserEmail.IsVisible = true;
                    lblUserEmail.Text = currentUser.Username;
                    lblUserName.Text = string.Format("{0} {1}", currentUser.FirstName, currentUser.LastName);
                }
                else
                {
                    lblUserEmail.IsVisible = false;
                    lblUserName.Text = currentUser.Username;
                }
            }
            else
            {
                // Menu for guest
                listMenuItems.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSettings, MenuId = MenuScreenConst.MenuSettings });
                listMenuItems.Add(new MenuItem() { MenuTitle = MenuScreenConst.StringMenuSignOut, MenuId = MenuScreenConst.MenuSignOut });

                lblUserEmail.IsVisible = false;
                lblUserName.Text = currentUser.Username;
            }

            listMenu.SetDataSource(menuScreen.GetMenuListDataSource(listMenuItems));
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

