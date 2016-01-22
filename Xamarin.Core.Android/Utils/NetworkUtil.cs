using System;
using Android.Content;
using Android.Net;
using Android.Provider;

namespace Xamarin.Core.Android
{
    public class NetworkUtil
    {
        private readonly ConnectivityManager ConnectivityManager;

        public NetworkUtil(Context context)
        {
            ConnectivityManager = context.GetSystemService(Context.ConnectivityService) as ConnectivityManager;
        }

        public bool IsWifiConnected()
        {
            var wifiNetworkInfo = ConnectivityManager.GetNetworkInfo(ConnectivityType.Wifi);
            return wifiNetworkInfo.IsConnected;
        }

        public bool IsMobileNetworkConnected()
        {
            var mobileNetworkInfo = ConnectivityManager.GetNetworkInfo(ConnectivityType.Mobile);
            return mobileNetworkInfo.IsRoaming && mobileNetworkInfo.IsConnected;
        }
    }
}

