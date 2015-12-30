using System;

namespace Xamarin.Core
{
    public interface IDialogBuilder
    {
        IDialog BuildSystemAlertDialog(string tag, string title, string message);
    }
}

