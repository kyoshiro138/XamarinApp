﻿using System;
using Xamarin.Core;

namespace App.Shared
{
    public interface IIntroScreen : IScreen, INavigationScreen
    {
        UserManager UserManager { get; }
    }
}

