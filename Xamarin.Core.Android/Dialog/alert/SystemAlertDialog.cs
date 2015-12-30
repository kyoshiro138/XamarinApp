using System;
using Android.Content;

namespace Xamarin.Core.Android
{
    public class SystemAlertDialog : BaseAlertDialog
    {
        public SystemAlertDialog(Context context)
            : base(context)
        {
        }

        public SystemAlertDialog(Context context, int theme)
            : base(context, theme)
        {
        }

        public SystemAlertDialog(Context context, bool cancelable, IDialogInterfaceOnCancelListener cancelListener)
            : base(context, cancelable, cancelListener)
        {
        }

        protected override void InitDialog(Context context)
        {
            SetCanceledOnTouchOutside(true);
            SetButton((int)DialogButtonType.Positive, "OK");
        }
    }
}

