using System;
using App.Shared;
using Xamarin.Core;
using Xamarin.Core.Android;
using Android.Views;

namespace App.Android
{
    public class IntroFragment : AppFragment, IIntroScreen
    {
        private MaterialLabel lblTitle;
        private IntroScreenLogic introSL;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_intro; }
        }

        protected override void BindControls(View rootView)
        {
            lblTitle = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_intro_title);
        }

        protected override void LoadData()
        {
            introSL = new IntroScreenLogic(this);

            introSL.InitializeScreen();
        }

        public override async void OnStart()
        {
            base.OnStart();

            if(introSL.IsUserSignedIn())
            {
                // TODO: Should navigate to home screen instead
                await introSL.NavigateWithDelay(new LoginFragment());
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
    }
}

