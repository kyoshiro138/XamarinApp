using System;
using Xamarin.Core;
using System.Threading.Tasks;

namespace App.Shared
{
    public class LoginScreenLogic
    {
        private readonly ILoginScreen loginScreen;
        private User CurrentLoginUser = null;

        public LoginScreenLogic(ILoginScreen screen)
        {
            loginScreen = screen;
        }

        public void InitializeScreen()
        {
            ILabel lblCreateAccount = loginScreen.GetControlByTag(LoginScreenConst.ControlLabelCreateAccount) as ILabel;
            ILabel lblUsername = loginScreen.GetControlByTag(LoginScreenConst.ControlLabelUsername) as ILabel;
            IButton btnNext = loginScreen.GetControlByTag(LoginScreenConst.ControlButtonNext) as IButton;
            IButton btnSignIn = loginScreen.GetControlByTag(LoginScreenConst.ControlButtonSignIn) as IButton;
            IButton btnBack = loginScreen.GetControlByTag(LoginScreenConst.ControlButtonBack) as IButton;
            ITextField tfUsername = loginScreen.GetControlByTag(LoginScreenConst.ControlTextFieldUsername) as ITextField;
            ITextField tfPassword = loginScreen.GetControlByTag(LoginScreenConst.ControlTextFieldPassword) as ITextField;

            lblCreateAccount.Text = LoginScreenConst.StringCreateAccount;
            btnNext.Text = LoginScreenConst.StringButtonNext;
            btnSignIn.Text = LoginScreenConst.StringButtonSignIn;
            btnBack.Text = LoginScreenConst.StringButtonBack;

            tfUsername.ErrorEnabled = true;
            tfUsername.Label = LoginScreenConst.StringLabelUsername;
            tfUsername.InputType = InputType.TextEmail;

            tfPassword.ErrorEnabled = true;
            tfPassword.Label = LoginScreenConst.StringLabelPassword;
            tfPassword.InputType = InputType.TextPassword;
        }

        public async Task HandleNextButton()
        {
            ITextField tfUsername = loginScreen.GetControlByTag(LoginScreenConst.ControlTextFieldUsername) as ITextField;
            string username = tfUsername.Input;
            if (!string.IsNullOrEmpty(username))
            {
                await loginScreen.UserManager.RequestUserBasicInfo(username);
            }
            else
            {
                tfUsername.Error = LoginScreenConst.ErrorUsernameEmpty;
            }
        }

        public async Task HandleSignIn()
        {
            ITextField tfPassword = loginScreen.GetControlByTag(LoginScreenConst.ControlTextFieldPassword) as ITextField;
            string password = tfPassword.Input;
            if (!string.IsNullOrEmpty(password))
            {
                if (CurrentLoginUser != null)
                {
                    await loginScreen.UserManager.RequestAuthentication(CurrentLoginUser, password);
                }
            }
            else
            {
                tfPassword.Error = LoginScreenConst.ErrorPasswordEmpty;
            }
        }

        public async Task HandleGuestSignIn(string username)
        {
            User user = new User();
            user.UserId = 0;
            user.Username = username;
            user.Role = (int)User.RoleType.Guest;

            CurrentLoginUser = user;
            await loginScreen.UserManager.SaveUserAuthentication(CurrentLoginUser, "");
        }

        public void UpdateUserBasicInfo(User user)
        {
            CurrentLoginUser = user;

            ILabel lblUsername = loginScreen.GetControlByTag(LoginScreenConst.ControlLabelUsername) as ILabel;
            lblUsername.Text = user.Username;
        }

        public async Task SaveAuthenticationKey(string key)
        {
            if (CurrentLoginUser != null && !string.IsNullOrEmpty(key))
            {
                await loginScreen.UserManager.SaveUserAuthentication(CurrentLoginUser, key);
            }
        }

        public void NavigateToHome(IScreen home)
        {
            loginScreen.Navigator.NavigateTo(home, true);
        }

        public void ShowUsernameErrorDialog(string message)
        {
            var dialog = loginScreen.BuildUsernameErrorDialog(message);
            dialog.Show();
        }

        public void ShowPasswordIncorrectDialog(string message)
        {
            var dialog = loginScreen.BuildPasswordIncorrectDialog(message);
            dialog.Show();
        }
    }
}

