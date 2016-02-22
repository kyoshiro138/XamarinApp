using System;
using Android.Content;
using Android.Runtime;
using Android.Widget;

namespace Xamarin.Core.Android
{
    public abstract class BaseGridItemView<T> : RelativeLayout where T : class
    {
        protected abstract int GridItemLayoutResId { get; }

        public T ItemData { get; private set; }

        public bool IsSelected { get; set; }

        protected BaseGridItemView(Context context)
            : base(context)
        {
            InflateItemView(context);
        }

        protected BaseGridItemView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        private void InflateItemView(Context context)
        {
            Inflate(context, GridItemLayoutResId, this);

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

