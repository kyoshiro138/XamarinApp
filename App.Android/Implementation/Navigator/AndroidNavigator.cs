﻿using System;
using Xamarin.Core.Android;
using Android.Support.V4.App;
using Newtonsoft.Json;
using Android.OS;

namespace App.Android
{
    public class AndroidNavigator : BaseNavigator, IParamTransfer
    {
        public static readonly string PARAM_TAG = "PARAM_TAG";

        public AndroidNavigator(int fragmentContainerId, FragmentManager fragmentManager)
            : base(fragmentContainerId, fragmentManager)
        {
            
        }

        public string SendParamByString(object param)
        {
            return JsonConvert.SerializeObject(param);
        }

        public Bundle CreateParamBundle(object param, string tag)
        {
            Bundle bundle = new Bundle();
            bundle.PutString(PARAM_TAG, tag);

            switch(tag)
            {
                case "TEST":
                    string paramString = JsonConvert.SerializeObject(param);
                    bundle.PutString(tag, paramString);
                    break;
            }

            return bundle;
        }
    }
}
