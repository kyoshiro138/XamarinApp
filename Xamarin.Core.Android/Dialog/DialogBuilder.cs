using System;
using Android.Content;

namespace Xamarin.Core.Android
{
    public class DialogBuilder : IDialogBuilder
    {
        private IDialog CurrentActiveDialog = null;

        public Context Context { get; private set; }

        public DialogBuilder(Context context)
        {
            Context = context;
        }

        public IDialog BuildSystemAlertDialog(string tag, string title, string message)
        {
            if (CurrentActiveDialog != null && CurrentActiveDialog.Tag.Equals(tag))
            {
                var dialog = CurrentActiveDialog as SystemAlertDialog;
                dialog.SetTitle(title);
                dialog.SetMessage(message);
            }
            else
            {
                var dialog = new SystemAlertDialog(Context);
                dialog.Tag = tag;
                dialog.SetTitle(title);
                dialog.SetMessage(message);

                CurrentActiveDialog = dialog;
            }
            return CurrentActiveDialog;
        }
    }
}

