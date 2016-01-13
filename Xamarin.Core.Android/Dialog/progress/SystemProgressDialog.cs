using System;
using Android.App;
using Android.Content;

namespace Xamarin.Core.Android
{
    public class SystemProgressDialog : ProgressDialog, IDialog
    {
        public string Tag { get; set; }

        public SystemProgressDialog(Context context)
            : base(context)
        {
        }

        public SystemProgressDialog(Context context, int theme)
            : base(context, theme)
        {
        }

        public void SetButton(int whichButton, string text)
        {
        }
    }
}

