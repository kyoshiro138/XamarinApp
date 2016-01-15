using Xamarin.Core;

namespace App.Shared
{
    public interface ILoginScreen : IScreen, INavigationScreen
    {
        UserManager UserManager { get; }

        IDialog BuildUsernameErrorDialog(string message);

        IDialog BuildPasswordIncorrectDialog(string message);
    }
}

