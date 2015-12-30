using Android.Views;

namespace App.Android
{
    public class HomeFragment : AppFragment
    {
        protected override int FragmentLayoutResId
        {
            get
            {
                return Resource.Layout.fragment_content;
            }
        }

        protected override void BindControls(View rootView)
        {
        }
        protected override void LoadData()
        {
        }
    }
}

