using Android.Views;
using App.Shared;
using Xamarin.Core;
using Android.Content;

namespace App.Android
{
    public class HomeFragment : AppFragment, IHomeScreen
    {
        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_content; }
        }

        public UserManager UserManager { get; private set; }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
            DrawerActivity.SetDrawersEnabled(true);
            Toolbar.Show();
        }

        protected override void BindControls(View rootView)
        {
        }

        protected override void LoadData()
        {
        }

        public IControl GetControlByTag(string tag)
        {
            throw new System.NotImplementedException();
        }
    }
}

