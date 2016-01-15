﻿using Android.App;
using Android.OS;

namespace App.Android
{
    [Activity(Label = "App.Android", Theme = "@style/LightTheme", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppDrawerActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentFragment(new IntroFragment());
            SetLeftDrawerFragment(new MenuFragment());
        }
    }
}


