using System;
using Xamarin.Core;
using System.Threading.Tasks;

namespace App.Shared
{
    public class LoginScreenLogic
    {
        private readonly ILoginScreen loginScreen;

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

            tfPassword.ErrorEnabled = true;
            tfPassword.Label = LoginScreenConst.StringLabelPassword;
        }

        public async Task HandleNextButton()
        {
            ITextField tfUsername = loginScreen.GetControlByTag(LoginScreenConst.ControlTextFieldUsername) as ITextField;
            string username = tfUsername.Input;
            if (!string.IsNullOrEmpty(username))
            {
                await loginScreen.UserManager.StartGetBasicInfo(username);
            }
            else
            {
                tfUsername.Error = LoginScreenConst.ErrorUsernameEmpty;
            }
        }

        public void UpdateUserBasicInfo(User user)
        {
            ILabel lblUsername = loginScreen.GetControlByTag(LoginScreenConst.ControlLabelUsername) as ILabel;
            lblUsername.Text = user.Username;
        }

        public void ShowUserErrorDialog(string message)
        {
            
        }
    }
}

