using System;
using App.Shared;
using Xamarin.Core.Android;
using Android.Content;
using System.Collections.Generic;

namespace App.Android
{
    public class LocationListAdapter : BaseListAdapter<LocationItemView, PlaceLocation>
    {
        public LocationListAdapter(Context context, List<PlaceLocation> data)
            : base(context, data)
        {
        }
    }
}

