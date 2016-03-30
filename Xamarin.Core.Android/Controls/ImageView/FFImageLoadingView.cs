using Android.Content;
using Android.Util;
using FFImageLoading;
using FFImageLoading.Views;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class FFImageLoadingView : ImageViewAsync, IUrlImageView
    {
        private string imageUrl;

        public string DefaultPlaceHolderPath { get; set; }

        public string ErrorPlaceHolderPath { get; set; }

        public bool IsVisible
        {
            get { return (Visibility == ViewStates.Visible); }
            set { Visibility = (value ? ViewStates.Visible : ViewStates.Gone); }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
        }

        public FFImageLoadingView(Context context)
            : base(context)
        {
        }

        public FFImageLoadingView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public void LoadImageFromUrl(string url)
        {
            imageUrl = url;
            var task = ImageService.LoadUrl(url);
            if (!string.IsNullOrEmpty(DefaultPlaceHolderPath))
            {
                task = task.LoadingPlaceholder(DefaultPlaceHolderPath);
            }
            if (!string.IsNullOrEmpty(ErrorPlaceHolderPath))
            {
                task = task.ErrorPlaceholder(ErrorPlaceHolderPath);
            }
            task.Into(this);
        }
    }
}

