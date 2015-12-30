using Android.Widget;
using Android.Content;
using System;
using Android.Runtime;

namespace Xamarin.Core.Android
{
    public abstract class BaseListItemView<T> : RelativeLayout where T : class
    {
        public T ItemData { get; private set; }

        public bool IsSelected { get; set; }

        protected BaseListItemView(Context context) : base(context)
        {
        }

        protected BaseListItemView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            
        }

        public virtual void LoadItemData(T data)
        {
            ItemData = data;
        }
    }
}

