using Android.Content;
using Android.Util;
using Koush;

namespace Xamarin.Core.Android
{
    public class UrlImageView : SystemImageView, IUrlImageView
    {
        private string imageUrl;

        public string DefaultPlaceHolderPath { get; set; }

        public string ErrorPlaceHolderPath { get; set; }

        public string ImageUrl
        {
            get { return imageUrl; }
        }

        public UrlImageView(Context context)
            : base(context)
        {
        }

        public UrlImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public UrlImageView(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
        }

        protected override void InitImageView(Context context, IAttributeSet attrs = null)
        {

        }

        public void LoadImageFromUrl(string url)
        {
            imageUrl = url;
            UrlImageViewHelper.SetUrlDrawable(this, url);
        }
    }
}

