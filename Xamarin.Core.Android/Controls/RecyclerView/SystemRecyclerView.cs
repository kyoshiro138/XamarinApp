using System;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Content;

namespace Xamarin.Core.Android
{
    public class SystemRecyclerView : RecyclerView
    {
        private ItemLayoutType layoutType;

        public ItemLayoutType LayoutType
        {
            get { return layoutType; }
            set
            {
                layoutType = value;
                if (layoutType == ItemLayoutType.ListVertical)
                {
                    LayoutManager layoutManager = new LinearLayoutManager(Context, LinearLayoutManager.Vertical, false);
                    SetLayoutManager(layoutManager);
                }
                else if (layoutType == ItemLayoutType.ListHorizonal)
                {
                    LayoutManager layoutManager = new LinearLayoutManager(Context, LinearLayoutManager.Horizontal, false);
                    SetLayoutManager(layoutManager);
                }
                else if (layoutType == ItemLayoutType.Grid)
                {
                    LayoutManager layoutManager = new GridLayoutManager(Context, 1);
                    SetLayoutManager(layoutManager);
                }
            }
        }

        public SystemRecyclerView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
            
        }

        public SystemRecyclerView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {

        }

        public SystemRecyclerView(Context context)
            : base(context)
        {

        }

        public enum ItemLayoutType
        {
            ListHorizonal,
            ListVertical,
            Grid
        }
    }
}

