using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;

namespace Xamarin.Core.Android
{
    public abstract class BaseFragmentActivity : AppCompatActivity
    {
        protected abstract int ActivityLayoutResource { get; }

        protected abstract int FragmentContainerId { get; }

        protected bool ExitAppOnBack { get; set; }

        protected int ExitAppOnBackDelay { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(ActivityLayoutResource);

            ExitAppOnBack = true;
            ExitAppOnBackDelay = 2 * 1000;
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Fragment fragment = SupportFragmentManager.FindFragmentById(FragmentContainerId);
            if (fragment != null)
            {
                fragment.OnActivityResult(requestCode, (int)resultCode, data);
            }
        }

        public override void OnBackPressed()
        {
            if (SupportFragmentManager.BackStackEntryCount > 1)
            {
                base.OnBackPressed();
            }
            else
            {
                if (ExitAppOnBack)
                {
                    Finish();
                }
                else
                {
                    ExitAppOnBack = true;
                    Toast.MakeText(this, "Please click BACK again to exit", ToastLength.Short).Show();

                    new Handler().PostDelayed(() =>
                        {
                            ExitAppOnBack = false;
                        }, ExitAppOnBackDelay);
                }
            }
        }

        protected void SetContentFragment(Fragment fragment)
        {
            var trasaction = SupportFragmentManager.BeginTransaction();
            trasaction.Replace(FragmentContainerId, fragment, fragment.Class.SimpleName);
            trasaction.AddToBackStack(null);
            trasaction.Commit();
        }
    }
}

