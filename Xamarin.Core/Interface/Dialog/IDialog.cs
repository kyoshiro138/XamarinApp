using System;

namespace Xamarin.Core
{
    public interface IDialog
    {
        string Tag { get; set; }

        void SetTitle(string title);

        void SetMessage(string message);

        void SetButton(int whichButton, string text);

        void Dismiss();

        void Show();
    }
}

