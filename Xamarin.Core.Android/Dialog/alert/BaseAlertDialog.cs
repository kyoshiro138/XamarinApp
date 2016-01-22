using System;
using Android.Support.V7.App;
using Android.Content;

namespace Xamarin.Core.Android
{
    public abstract class BaseAlertDialog : AlertDialog, IDialog, 
            IDialogInterfaceOnClickListener, IDialogInterfaceOnDismissListener, IDialogInterfaceOnCancelListener
    {
        public string Tag { get; set; }

        public event EventHandler<OnDialogButtonClickEventArgs> OnButtonClicked;
        public event EventHandler<EventArgs> OnDialogClosed;

        protected BaseAlertDialog(Context context)
            : base(context)
        {
            InitDialog(context);
            SetOnCancelListener(this);
        }

        protected BaseAlertDialog(Context context, int theme)
            : base(context, theme)
        {
            InitDialog(context);
            SetOnCancelListener(this);
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

        public void OnDismiss(IDialogInterface dialog)
        {
            if (OnDialogClosed != null)
            {
                OnDialogClosed.Invoke(this, new EventArgs());
                OnDialogClosed = null;
            }

            OnButtonClicked = null;
        }

        public void OnCancel(IDialogInterface dialog)
        {
            if (OnDialogClosed != null)
            {
                OnDialogClosed.Invoke(this, new EventArgs());
                OnDialogClosed = null;
            }

            OnButtonClicked = null;
        }
    }
}

