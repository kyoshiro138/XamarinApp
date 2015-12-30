using System;
using Android.Support.V7.App;
using Android.Content;

namespace Xamarin.Core.Android
{
    public abstract class BaseAlertDialog : AlertDialog, IDialog, IDialogInterfaceOnClickListener
    {
        public string Tag { get; set; }

        public event EventHandler<OnDialogButtonClickEventArgs> OnButtonClicked;

        protected BaseAlertDialog(Context context)
            : base(context)
        {
            InitDialog(context);
        }

        protected BaseAlertDialog(Context context, int theme)
            : base(context, theme)
        {
            InitDialog(context);
        }

        protected BaseAlertDialog(Context context, bool cancelable, IDialogInterfaceOnCancelListener cancelListener)
            : base(context, cancelable, cancelListener)
        {
            InitDialog(context);
        }

        protected abstract void InitDialog(Context context);

        public void SetButton(int whichButton, string text)
        {
            SetButton(whichButton, text, this);
        }

        public void OnClick(IDialogInterface dialog, int which)
        {
            if (OnButtonClicked != null)
            {
                var args = new OnDialogButtonClickEventArgs(Tag, which);
                OnButtonClicked.Invoke(this, args);
                OnButtonClicked = null;
            }

            dialog.Dismiss();
        }
    }
}

