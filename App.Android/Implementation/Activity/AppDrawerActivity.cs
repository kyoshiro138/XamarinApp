using Xamarin.Core.Android;
using Android.OS;

namespace App.Android
{
    public class AppDrawerActivity : BaseDrawerActivity
    {
        protected override int ActivityLayoutResource
        {
            get { return Resource.Layout.activity_navigation_drawer; }
        }

        protected override int FragmentContainerId
        {
            get { return Resource.Id.layout_content; }
        }

        protected override int DrawerLayoutId
        {
            get { return Resource.Id.layout_drawer; }
        }

        protected override int LeftDrawerFragContainerId
        {
            get { return Resource.Id.layout_left_drawer; }
        }

        protected override int RightDrawerFragContainerId
        {
            get { return Resource.Id.layout_right_drawer; }
        }

        public AndroidNavigator Navigator { get; private set; }

        public SystemSupportToolbar Toolbar { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
//            Window.SetFlags(WindowManagerFlags.TranslucentStatus, WindowManagerFlags.TranslucentStatus);
            Navigator = new AndroidNavigator(FragmentContainerId, SupportFragmentManager);
            Toolbar = FindViewById<SystemSupportToolbar>(Resource.Id.toolbar);

            ExitAppOnBack = false;
        }
    }
}

