using System;
using Android.Content;
using Android.Util;
using Android.OS;
using Android.Support.V4.Content;
using Android.Content.Res;

namespace Xamarin.Core.Android
{
    public class ResourceUtil
    {
        private Context Context;

        public ResourceUtil(Context context)
        {
            Context = context;
        }

        public ColorStateList GetColorFromAttribute(int attrResId)
        {
            var colorValue = new TypedValue();
            Context.Theme.ResolveAttribute(attrResId, colorValue, true);
            int resId = colorValue.ResourceId;
            colorValue.Dispose();

            int version = int.Parse(Build.VERSION.Sdk);
            if (version >= 23)
            {
                return ContextCompat.GetColorStateList(Context, resId);
            }
            else
            {
                return Context.Resources.GetColorStateList(resId);
            }
        }
    }
}

