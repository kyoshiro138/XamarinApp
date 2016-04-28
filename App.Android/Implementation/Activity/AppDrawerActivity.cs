using Xamarin.Core.Android;
using Android.OS;
using FFImageLoading;
using System.Net.Http;
using ModernHttpClient;
using FFImageLoading.Config;
using Android.Support.V7.Widget;

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

        public AndroidNavigator Navigator { get; protected set; }

        public AndroidToolbar Toolbar { get; protected set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Navigator = new AndroidNavigator(FragmentContainerId, SupportFragmentManager);
            Toolbar = FindViewById<AndroidToolbar>(Resource.Id.toolbar);

            InitImageLoadingConfig();

            ExitAppOnBack = false;
//            SetSupportActionBar(Toolbar);
//            SupportActionBar.Hide();
        }

        private void InitImageLoadingConfig()
        {
            Configuration config = new Configuration();
            config.HttpClient = new HttpClient(new NativeMessageHandler());
            ImageService.Initialize(config);
        }
    }
}

