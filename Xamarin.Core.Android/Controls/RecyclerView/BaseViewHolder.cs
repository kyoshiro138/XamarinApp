using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace Xamarin.Core.Android
{
    public abstract class BaseViewHolder<TItemData> : RecyclerView.ViewHolder
        where TItemData : class
    {
        protected BaseViewHolder(View itemView)
            : base(itemView)
        {

        }

        public abstract void LoadData(TItemData data);
    }
}

