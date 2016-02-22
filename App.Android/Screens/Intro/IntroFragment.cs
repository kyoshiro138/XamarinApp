using System;
using App.Shared;
using Xamarin.Core;
using Xamarin.Core.Android;
using Android.Views;

namespace App.Android
{
    public class IntroFragment : AppFragment, IIntroScreen
    {
        private ILabel lblTitle;
        private IntroScreenLogic introSL;
        private AppAndroidDatabaseManager database;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_intro; }
        }

        protected override void BindControls(View rootView)
        {
            lblTitle = rootView.FindViewById<SystemLabel>(Resource.Id.lbl_intro_title);
        }

        protected override void LoadData()
        {
            var service = new AppService(Context);
            service.OnResponseSuccess += Service_OnResponseSuccess;
            service.OnResponseFailed += Service_OnResponseFailed;
            service.Dialog = new SystemProgressDialog(Activity);

            database = new AppAndroidDatabaseManager(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            var appPref = new ApplicationPreferences();

            UserManager = new UserManager(service, database, appPref);

            introSL = new IntroScreenLogic(this);
            introSL.InitializeScreen();
        }

        public override async void OnStart()
        {
            base.OnStart();
            await database.InitDatabase();
            bool isUserSignedIn = await introSL.IsUserSignedIn();
            if (isUserSignedIn)
            {
                await introSL.NavigateWithDelay(new HomeFragment());
            }
            else
            {
                await introSL.NavigateWithDelay(new LoginFragment());
            }
        }

        public IControl GetControlByTag(string tag)
        {
            switch (tag)
            {
                case IntroScreenConst.ControlLabelTitle:
                    return lblTitle;
                default:
                    return null;
            }
        }

        private void Service_OnResponseFailed(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {

        }

        private void Service_OnResponseSuccess(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            switch (e.RequestTag)
            {
                case LoginScreenConst.ServiceGetBasicInfo:
                    break;
                case LoginScreenConst.ServiceAuthenticate:
                    break;
            }
        }
    }
}

