using Android.Content;
using Android.Util;
using FFImageLoading;
using FFImageLoading.Views;
using Android.Views;
using System;
using Android.Runtime;

namespace Xamarin.Core.Android
{
    public class FFImageLoadingView : ImageViewAsync, IUrlImageView
    {
        private string _imageUrl = string.Empty;

        public string DefaultPlaceHolderPath { get; set; }

        public string ErrorPlaceHolderPath { get; set; }

        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
        }

        protected FFImageLoadingView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public FFImageLoadingView(Context context)
            : base(context)
        {
            InitImageView(context);
        }

        public FFImageLoadingView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            InitImageView(context, attrs);
        }

        protected virtual void InitImageView(Context context, IAttributeSet attrs = null)
        {
        }

        public void LoadImageFromUrl(string url)
        {
            _imageUrl = url;
            var task = ImageService.LoadUrl(url);
            if (!string.IsNullOrEmpty(DefaultPlaceHolderPath))
            {
                task = task.LoadingPlaceholder(DefaultPlaceHolderPath, FFImageLoading.Work.ImageSource.ApplicationBundle);
            }
            if (!string.IsNullOrEmpty(ErrorPlaceHolderPath))
            {
                task = task.ErrorPlaceholder(ErrorPlaceHolderPath, FFImageLoading.Work.ImageSource.ApplicationBundle);
            }
            task.Into(this);
        }
    }
}

