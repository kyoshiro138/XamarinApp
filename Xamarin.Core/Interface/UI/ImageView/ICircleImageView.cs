using System;

namespace Xamarin.Core
{
    public interface ICircleImageView : IImageView
    {
        string FillColorString { set; }

        string BorderColorString { set; }

        int BorderWidth { get; set; }

        bool BorderOverlay { get; set; }
    }
}

