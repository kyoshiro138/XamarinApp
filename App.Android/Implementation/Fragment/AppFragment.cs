using Xamarin.Core.Android;
using Android.Content;
using Xamarin.Core;
using Android.OS;

namespace App.Android
{
    public abstract class AppFragment : BaseFragment, INavigationScreen, IToolbarScreen
    {
        protected AppDrawerActivity DrawerActivity { get; private set; }

        public App.Shared.UserManager UserManager { get; protected set; }

        public App.Shared.TravelManager TravelManager { get; protected set; }

        public INavigator Navigator
        {
            get
            {
                if (DrawerActivity != null)
                {
                    return DrawerActivity.Navigator;
                }
                return null;
            }
        }

        public IToolbar Toolbar
        {
            get
            {
                if (DrawerActivity != null)
                {
                    return DrawerActivity.Toolbar;
                }
                return null;
            }
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);

            DrawerActivity = context as AppDrawerActivity;
            DrawerActivity.SetDrawersEnabled(false);

            Toolbar.Hide();
        }
    }

    public abstract class AppFragment<TParam> : AppFragment, IParamReceive<TParam> where TParam : class
    {
        protected TParam ReceivedParam { get; private set; }

        public abstract TParam ReceiveParamObject(Bundle param, string tag);

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            Bundle arg = Arguments;
            if (arg != null)
            {
                string paramTag = arg.GetString(AndroidNavigator.PARAM_TAG);
                if (!string.IsNullOrEmpty(paramTag))
                {
                    ReceivedParam = ReceiveParamObject(arg, paramTag);
                }
            }
        }
    }
}

