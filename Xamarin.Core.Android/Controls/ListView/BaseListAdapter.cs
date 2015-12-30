using System;
using Android.Widget;
using Android.Views;
using Android.Content;
using System.Collections.Generic;
using Android.Runtime;

namespace Xamarin.Core.Android
{
    public class BaseListAdapter<TItemView, TItemData> : BaseAdapter, IListDataSource<TItemData>
        where TItemView : BaseListItemView<TItemData>
        where TItemData : class
    {

        private List<TItemData> Data;
        public List<TItemData> DataSource
        { 
            get { return Data; }
            set
            {
                if (Data == null)
                {
                    Data = new List<TItemData>();
                }
                Data.Clear();
                Data.AddRange(value);
                NotifyDataSetChanged();
            }
        }

        public Context Context { get; private set; }

        public override int Count
        {
            get
            {
                if (DataSource != null)
                {
                    return DataSource.Count;
                }
                return 0;
            }
        }

        public BaseListAdapter(Context context, List<TItemData> data) : base()
        {
            Context = context;
            DataSource = data;
        }

        public BaseListAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                convertView = (TItemView)Activator.CreateInstance(typeof(TItemView), Context);
            }

            TItemView itemView = (TItemView)convertView;
            itemView.LoadItemData(DataSource[position]);

            return convertView;
        }
    }
}

