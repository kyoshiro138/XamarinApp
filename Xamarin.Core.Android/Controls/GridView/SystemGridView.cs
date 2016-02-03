using Android.Widget;
using Android.Content;
using Android.Util;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class SystemGridView : GridView, IGridView
    {
        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = value ? ViewStates.Visible : ViewStates.Gone; }
        }

        public SystemGridView(Context context)
            : base(context)
        {
            InitGridView();
        }

        public SystemGridView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitGridView();
        }

        public SystemGridView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitGridView();
        }

        protected virtual void InitGridView()
        {
        }

        public void SetDataSource<T>(IGridDataSource<T> dataSource) where T : class
        {
            var dataAdapter = dataSource as BaseAdapter;
            if (dataAdapter != null)
            {
                Adapter = dataAdapter;
            }
        }
    }
}

