using System;

namespace Xamarin.Core
{
    public interface IUrlImageView : IImageView
    {
        string DefaultPlaceHolderPath { get; set; }

        string ErrorPlaceHolderPath { get; set; }

        string ImageUrl { get; }

        void LoadImageFromUrl(string url);
    }
}

