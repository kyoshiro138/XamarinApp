using System;
using Android.Support.V4.App;
using Fragment = Android.Support.V4.App.Fragment;
using Android.OS;

namespace Xamarin.Core.Android  
{
    public class BaseNavigator : INavigator
    {
        protected int FragmentContainerId { get; private set; }

        protected FragmentManager FragmentManager { get; private set; }

        public BaseNavigator(int fragmentContainerId, FragmentManager fragmentManager)
        {
            FragmentContainerId = fragmentContainerId;
            FragmentManager = fragmentManager;
        }

        public void NavigateTo(IScreen screen)
        {
            Fragment fragment = screen as Fragment;
            if (fragment != null && IsNavigable())
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                transaction.SetCustomAnimations(Android.Resource.Animation.abc_fade_in, Android.Resource.Animation.abc_fade_out);
                transaction.Replace(FragmentContainerId, fragment, fragment.Class.SimpleName);
                transaction.AddToBackStack(null);
                transaction.Commit();
            }
        }

        public void NavigateTo<TParam>(IScreen screen, TParam param, string paramTag)
        {
            Fragment fragment = screen as Fragment;
            if (fragment != null && IsNavigable())
            {
                var transferableNavigator = this as IParamTransfer;
                if(transferableNavigator != null)
                {
                    Bundle arg = transferableNavigator.CreateParamBundle(param, paramTag);

                    fragment.Arguments = arg;
                }

                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                transaction.SetCustomAnimations(Android.Resource.Animation.abc_fade_in, Android.Resource.Animation.abc_fade_out);
                transaction.Replace(FragmentContainerId, fragment, fragment.Class.SimpleName);
                transaction.AddToBackStack(null);
                transaction.Commit();
            }
        }

        public void NavigateBack()
        {
            if (FragmentManager != null)
            {
                FragmentManager.PopBackStack();
            }
        }

        private bool IsNavigable()
        {
            return (FragmentContainerId > 0 && FragmentManager != null);
        }
    }
}

