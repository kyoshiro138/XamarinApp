using System;
using Android.Content;
using Android.Runtime;
using Android.Widget;

namespace Xamarin.Core.Android
{
    public abstract class BaseGridItemView<T> : RelativeLayout where T : class
    {
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

        protected abstract void InflateItemView(Context context);

        public virtual void LoadItemData(T data)
        {
            ItemData = data;
        }
    }
}

