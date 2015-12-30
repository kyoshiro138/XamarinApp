using System;
using Xamarin.Core;
using System.Collections.Generic;

namespace App.Shared
{
    public class MenuScreenLogic
    {
        private readonly IMenuScreen menuScreen;

        public MenuScreenLogic(IMenuScreen screen)
        {
            menuScreen = screen;
        }

        public void InitMenuList()
        {
            List<MenuItem> menuList = new List<MenuItem>();
            menuList.Add(new MenuItem() { Title = "Menu 1", ScreenTag = "" });
            menuList.Add(new MenuItem() { Title = "Menu 2", ScreenTag = "" });
            menuList.Add(new MenuItem() { Title = "Menu 3", ScreenTag = "" });
            menuList.Add(new MenuItem() { Title = "Menu 4", ScreenTag = "" });

            IListView menuListView = menuScreen.GetControlByTag(MenuScreenConst.ControlListView) as IListView;
            menuListView.SetDataSource(menuScreen.GetMenuListDataSource(menuList));
        }
    }
}

