using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace Xamarin.Core.Android
{
    public abstract class BaseFragment : Fragment, ViewTreeObserver.IOnGlobalLayoutListener
    {
        protected abstract int FragmentLayoutResId { get; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(FragmentLayoutResId, container, false);

            BindControls(view);
            view.ViewTreeObserver.AddOnGlobalLayoutListener(this);

            return view;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            LoadData();
        }

        public void OnGlobalLayout()
        {
            // Removing layout listener to avoid multiple calls
            View.ViewTreeObserver.RemoveOnGlobalLayoutListener(this);
            OnDisplayed();
        }

        protected abstract void BindControls(View rootView);

        protected abstract void LoadData();

        protected virtual void OnDisplayed()
        {
            
        }
    }
}

