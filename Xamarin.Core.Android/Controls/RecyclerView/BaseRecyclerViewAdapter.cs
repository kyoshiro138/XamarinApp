using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;

namespace Xamarin.Core.Android
{
    public abstract class BaseRecyclerViewAdapter<TItemViewHolder, TItemData> : RecyclerView.Adapter
        where TItemViewHolder : BaseViewHolder<TItemData>
        where TItemData : class
    {
        public int ItemLayoutResId { get; private set; }

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

        public override int ItemCount
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

        protected BaseRecyclerViewAdapter(List<TItemData> data, int itemLayoutResId)
        {
            Data = data;
            ItemLayoutResId = itemLayoutResId;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(ItemLayoutResId, parent, false); 
            TItemViewHolder viewHolder = (TItemViewHolder)Activator.CreateInstance(typeof(TItemViewHolder), itemView);
            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TItemViewHolder viewHolder = holder as TItemViewHolder;
            viewHolder.LoadData(DataSource[position]);
        }
    }
}

