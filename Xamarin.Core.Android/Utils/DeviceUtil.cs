using System;
using Android.OS;

namespace Xamarin.Core.Android
{
    public static class DeviceUtil
    {
        public static bool IsEmulator()
        {
            string fing = Build.Fingerprint;
            if (fing != null)
            {
                return fing.Contains("vbox") || fing.Contains("generic");
            }
            return false;
        }
    }
}

