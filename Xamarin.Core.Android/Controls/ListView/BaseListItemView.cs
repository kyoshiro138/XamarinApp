using Android.Widget;
using Android.Content;
using System;
using Android.Runtime;

namespace Xamarin.Core.Android
{
    public abstract class BaseListItemView<T> : RelativeLayout where T : class
    {
        protected abstract int ListItemLayoutResId { get; }

        public T ItemData { get; private set; }

        public bool IsSelected { get; set; }

        protected BaseListItemView(Context context)
            : base(context)
        {
            InflateItemView(context);
        }

        protected BaseListItemView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        private void InflateItemView(Context context)
        {
            Inflate(context, ListItemLayoutResId, this);

            BindControls();
        }

        protected virtual void BindControls()
        {
            
        }

        public virtual void LoadItemData(T data)
        {
            ItemData = data;
        }
    }
}

