﻿using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Xamarin.Core.Android
{
    public class SystemListView : ListView, IListView
    {
        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = value ? ViewStates.Visible : ViewStates.Gone; }
        }

        public SystemListView(Context context)
            : base(context)
        {
            InitListView();
        }

        public SystemListView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitListView();
        }

        public SystemListView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            InitListView();
        }

        protected virtual void InitListView()
        {
        }

        public void SetDataSource<T>(IListDataSource<T> dataSource) where T : class
        {
            var dataAdapter = dataSource as BaseAdapter;
            if (dataAdapter != null)
            {
                Adapter = dataAdapter;
            }
        }
    }
}

