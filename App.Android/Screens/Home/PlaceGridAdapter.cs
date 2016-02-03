using System;
using App.Shared;
using Xamarin.Core.Android;
using Android.Content;
using System.Collections.Generic;

namespace App.Android
{
    public class PlaceGridAdapter : BaseGridAdapter<PlaceItemView,TravelPlace>
    {
        public PlaceGridAdapter(Context context, List<TravelPlace> data)
            : base(context, data)
        {
        }
    }
}

