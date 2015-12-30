using Android.Views;
using Xamarin.Core.Android;
using Xamarin.Core;
using App.Shared;

namespace App.Android
{
    public class MenuFragment : AppFragment, IMenuScreen
    {
        private XamarinListView menuList;
        private MenuScreenLogic menuSL;

        protected override int FragmentLayoutResId
        {
            get
            {
                return Resource.Layout.fragment_menu;
            }
        }

        protected override void BindControls(View rootView)
        {
            menuList = rootView.FindViewById<XamarinListView>(Resource.Id.list_menu);
        }

        protected override void LoadData()
        {
            menuSL = new MenuScreenLogic(this);
            menuSL.InitMenuList();
        }

        public IControl GetControlByTag(string tag)
        {
            if (View != null)
            {
                switch(tag)
                {
                    case MenuScreenConst.ControlListView:
                        return menuList;
                    default:
                        return null;
                }
            }
            return null;
        }

        public IListDataSource<MenuItem> GetMenuListDataSource(System.Collections.Generic.List<MenuItem> data)
        {
            return new MenuListAdapter(Context, data);
        }
    }
}

