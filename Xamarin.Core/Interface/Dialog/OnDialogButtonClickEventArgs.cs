using System;

namespace Xamarin.Core
{
    public class OnDialogButtonClickEventArgs : EventArgs
    {
        public string DialogTag {
            get;
            private set;
        }

        public int ButtonId {
            get;
            private set;
        }

        public OnDialogButtonClickEventArgs (string tag, int buttonId)
        {
            DialogTag = tag;
            ButtonId = buttonId;
        }
    }
}

