using System;
using Android.Content;
using Android.Views;
using Android.Widget;
using App.Shared;
using Xamarin.Core;
using Xamarin.Core.Android;
using System.Threading.Tasks;
using Android.Provider;

namespace App.Android
{
    public class LoginFragment : AppFragment, ILoginScreen
    {
        private View LayoutLogin;
        private View LayoutLoginUsername;
        private View LayoutLoginPassword;

        private FFImageLoadingCircleView imgAvatar;
        private MaterialLabel lblCreateAccount;
        private MaterialLabel lblUsername;
        private MaterialButton btnNext;
        private MaterialButton btnSignIn;
        private MaterialButton btnBack;
        private SinglelineTextField tfUsername;
        private SinglelineTextField tfPassword;

        private ZoomInAnimator LayoutAppearAnimator;
        private ZoomOutAnimator LayoutDisappearAnimator;
        private ResizeAnimator LayoutResizeAnimator;
        private FadeInAnimator ContentAppearAnimator;
        private FadeOutAnimator ContentDisappearAnimator;
        private FadeOutAnimator ContentHideAnimator;
        private FadeInAnimator AvatarAppearAnimator;
        private FadeOutAnimator AvatarDisappearAnimator;
        private FadeInAnimator RegisterAppearAnimator;
        private FadeOutAnimator RegisterDisappearAnimator;

        private LoginScreenLogic loginSL;
        private DialogBuilder dialogBuilder;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_login; }
        }

        protected override void BindControls(View rootView)
        {
            LayoutLogin = rootView.FindViewById(Resource.Id.card_login);
            LayoutLoginUsername = rootView.FindViewById(Resource.Id.layout_login_username);
            LayoutLoginPassword = rootView.FindViewById(Resource.Id.layout_login_password);

            imgAvatar = rootView.FindViewById<FFImageLoadingCircleView>(Resource.Id.img_login_avatar);
            lblCreateAccount = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_login_create_account);
            lblUsername = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_login_username);
            btnNext = rootView.FindViewById<MaterialButton>(Resource.Id.btn_login_next);
            btnSignIn = rootView.FindViewById<MaterialButton>(Resource.Id.btn_login_sign_in);
            btnBack = rootView.FindViewById<MaterialButton>(Resource.Id.btn_login_back);

            tfUsername = rootView.FindViewById<SinglelineTextField>(Resource.Id.tf_login_username);
            tfPassword = rootView.FindViewById<SinglelineTextField>(Resource.Id.tf_login_password);

            lblUsername.ApplyTextFontAndSizeByType(MaterialLabelType.Body2);
        }

        protected override void LoadData()
        {
            dialogBuilder = new DialogBuilder(Context);

            var service = new AppService(Context);
            service.OnResponseSuccess += Service_OnResponseSuccess;
            service.OnResponseFailed += Service_OnResponseFailed;
            service.Dialog = new SystemProgressDialog(Activity);

            var database = new AppAndroidDatabaseManager(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), Environment.GetFolderPath(Environment.SpecialFolder.Personal));
            var appPref = new ApplicationPreferences();

            UserManager = new UserManager(service, database, appPref);

            loginSL = new LoginScreenLogic(this);
            loginSL.InitializeScreen();
        }

        public IControl GetControlByTag(string tag)
        {
            switch (tag)
            {
                case LoginScreenConst.ControlImageAvatar:
                    return imgAvatar;
                case LoginScreenConst.ControlLabelCreateAccount:
                    return lblCreateAccount;
                case LoginScreenConst.ControlLabelUsername:
                    return lblUsername;
                case LoginScreenConst.ControlButtonNext:
                    return btnNext;
                case LoginScreenConst.ControlButtonSignIn:
                    return btnSignIn;
                case LoginScreenConst.ControlButtonBack:
                    return btnBack;
                case LoginScreenConst.ControlTextFieldUsername:
                    return tfUsername;
                case LoginScreenConst.ControlTextFieldPassword:
                    return tfPassword;
                default:
                    return null;
            }
        }

        protected override void OnDisplayed()
        {
            base.OnDisplayed();

            if (LayoutAppearAnimator != null)
            {
                LayoutAppearAnimator.SetAnimationView(LayoutLogin);
            }
            if (ContentAppearAnimator != null)
            {
                ContentAppearAnimator.SetAnimationView(LayoutLoginUsername);
            }
            if (AvatarAppearAnimator != null)
            {
                AvatarAppearAnimator.SetAnimationView(imgAvatar);
            }
            if (AvatarDisappearAnimator != null)
            {
                AvatarAppearAnimator.SetAnimationView(imgAvatar);
            }
            if (RegisterAppearAnimator != null)
            {
                RegisterAppearAnimator.SetAnimationView(lblCreateAccount);
            }

            LayoutAppearAnimator.Start();
        }

        public override void OnResume()
        {
            base.OnResume();

            InitAnimators();

            LayoutAppearAnimator.OnAnimationFinished += OnAnimationFinished;
            LayoutDisappearAnimator.OnAnimationFinished += OnAnimationFinished;
            AvatarAppearAnimator.OnAnimationStarting += OnAnimationStarting;
            ContentAppearAnimator.OnAnimationStarting += OnAnimationStarting;
            ContentDisappearAnimator.OnAnimationFinished += OnAnimationFinished;
            ContentHideAnimator.OnAnimationFinished += OnAnimationFinished;
            RegisterDisappearAnimator.OnAnimationFinished += OnAnimationFinished;
            RegisterAppearAnimator.OnAnimationStarting += OnAnimationStarting;

            btnNext.Click += OnButtonClicked;
            btnSignIn.Click += OnButtonClicked;
            btnBack.Click += OnButtonClicked;
        }

        public override void OnPause()
        {
            base.OnPause();

            LayoutAppearAnimator.OnAnimationFinished -= OnAnimationFinished;
            LayoutDisappearAnimator.OnAnimationFinished -= OnAnimationFinished;
            AvatarAppearAnimator.OnAnimationStarting -= OnAnimationStarting;
            ContentAppearAnimator.OnAnimationStarting -= OnAnimationStarting;
            ContentDisappearAnimator.OnAnimationFinished -= OnAnimationFinished;
            ContentHideAnimator.OnAnimationFinished -= OnAnimationFinished;
            RegisterDisappearAnimator.OnAnimationFinished -= OnAnimationFinished;
            RegisterAppearAnimator.OnAnimationStarting -= OnAnimationStarting;

            btnNext.Click -= OnButtonClicked;
            btnSignIn.Click -= OnButtonClicked;
            btnBack.Click -= OnButtonClicked;
        }

        private void InitAnimators()
        {
            if (LayoutAppearAnimator == null)
            {
                LayoutAppearAnimator = new ZoomInAnimator("LayoutAppearAnimator");
            }
            if (LayoutDisappearAnimator == null)
            {
                LayoutDisappearAnimator = new ZoomOutAnimator("LayoutDisappearAnimator");
            }
            if (LayoutResizeAnimator == null)
            {
                LayoutResizeAnimator = new ResizeAnimator("LayoutResizeAnimator");
            }
            if (ContentAppearAnimator == null)
            {
                ContentAppearAnimator = new FadeInAnimator("ContentAppearAnimator");
            }
            if (ContentDisappearAnimator == null)
            {
                ContentDisappearAnimator = new FadeOutAnimator("ContentDisappearAnimator");
            }
            if (ContentHideAnimator == null)
            {
                ContentHideAnimator = new FadeOutAnimator("ContentHideAnimator");
            }
            if (AvatarAppearAnimator == null)
            {
                AvatarAppearAnimator = new FadeInAnimator("AvatarAppearAnimator");
            }
            if (AvatarDisappearAnimator == null)
            {
                AvatarDisappearAnimator = new FadeOutAnimator("AvatarDisappearAnimator");
            }
            if (RegisterAppearAnimator == null)
            {
                RegisterAppearAnimator = new FadeInAnimator("RegisterAppearAnimator");
            }
            if (RegisterDisappearAnimator == null)
            {
                RegisterDisappearAnimator = new FadeOutAnimator("RegisterDisappearAnimator");
            }
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Id)
            {
                case Resource.Id.btn_login_next:
                    if (tfUsername.IsFocused)
                    {
                        tfUsername.ClearFocus();
                    }
                    await loginSL.HandleNextButton();
                    break;
                case Resource.Id.btn_login_sign_in:
                    if (tfPassword.IsFocused)
                    {
                        tfPassword.ClearFocus();
                    }
                    await loginSL.HandleSignIn();
                    break;
                case Resource.Id.btn_login_back:
                    if (tfPassword.IsFocused)
                    {
                        tfPassword.ClearFocus();
                    }
                    ShowUsernameLayout();
                    loginSL.ClearUserBasicInfo();
                    break;
            }
        }

        private void ShowUsernameLayout()
        {
            int usernameLayoutHeight = Resources.GetDimensionPixelSize(Resource.Dimension.d_login_layout_username_height);
            int passwordLayoutHeight = Resources.GetDimensionPixelSize(Resource.Dimension.d_login_layout_password_height);
            int heightChange = usernameLayoutHeight - passwordLayoutHeight;

            LayoutResizeAnimator.SetAnimationView(LayoutLogin);
            LayoutResizeAnimator.SetViewSizeAfterAnimated(LayoutLogin.Width, LayoutLogin.Height + heightChange);
            LayoutResizeAnimator.Start();

            ContentDisappearAnimator.SetAnimationView(LayoutLoginPassword);
            ContentAppearAnimator.SetAnimationView(LayoutLoginUsername);
            RegisterAppearAnimator.SetAnimationView(lblCreateAccount);

            ContentDisappearAnimator.Start();
            RegisterAppearAnimator.Start();
        }

        private void ShowPasswordLayout()
        {
            int usernameLayoutHeight = Resources.GetDimensionPixelSize(Resource.Dimension.d_login_layout_username_height);
            int passwordLayoutHeight = Resources.GetDimensionPixelSize(Resource.Dimension.d_login_layout_password_height);
            int heightChange = passwordLayoutHeight - usernameLayoutHeight;

            LayoutResizeAnimator.SetAnimationView(LayoutLogin);
            LayoutResizeAnimator.SetViewSizeAfterAnimated(LayoutLogin.Width, LayoutLogin.Height + heightChange);
            LayoutResizeAnimator.Start();

            ContentDisappearAnimator.SetAnimationView(LayoutLoginUsername);
            ContentAppearAnimator.SetAnimationView(LayoutLoginPassword);
            RegisterDisappearAnimator.SetAnimationView(lblCreateAccount);

            ContentDisappearAnimator.Start();
            RegisterDisappearAnimator.Start();
        }

        private void HideLoginUsernameLayout()
        {
            AvatarDisappearAnimator.SetAnimationView(imgAvatar);
            ContentHideAnimator.SetAnimationView(LayoutLoginUsername);
            LayoutDisappearAnimator.SetAnimationView(LayoutLogin);
            RegisterDisappearAnimator.SetAnimationView(lblCreateAccount);

            AvatarDisappearAnimator.Start();
            ContentHideAnimator.Start();
            RegisterDisappearAnimator.Start();
        }

        private void HideLoginPasswordLayout()
        {
            AvatarDisappearAnimator.SetAnimationView(imgAvatar);
            ContentHideAnimator.SetAnimationView(LayoutLoginPassword);
            LayoutDisappearAnimator.SetAnimationView(LayoutLogin);

            AvatarDisappearAnimator.Start();
            ContentHideAnimator.Start();
        }

        private void OnAnimationStarting(object sender, AnimatorEventArgs e)
        {
            BaseAnimator animator = sender as BaseAnimator;
            if (animator != null)
            {
                switch (animator.Tag)
                {
                    case "ContentAppearAnimator":
                    case "AvatarAppearAnimator":
                    case "RegisterAppearAnimator":
                        e.AnimationView.Visibility = ViewStates.Visible;
                        break;
                }
            }
        }

        private void OnAnimationFinished(object sender, AnimatorEventArgs e)
        {
            BaseAnimator animator = sender as BaseAnimator;
            if (animator != null)
            {
                switch (animator.Tag)
                {
                    case "LayoutAppearAnimator":
                        ContentAppearAnimator.Start();
                        AvatarAppearAnimator.Start();
                        RegisterAppearAnimator.Start();
                        break;
                    case "ContentDisappearAnimator":
                        e.AnimationView.Visibility = ViewStates.Gone;
                        ContentAppearAnimator.Start();
                        break;
                    case "RegisterDisappearAnimator":
                        e.AnimationView.Visibility = ViewStates.Gone;
                        break;
                    case "ContentHideAnimator":
                        LayoutDisappearAnimator.Start();
                        break;
                    case "LayoutDisappearAnimator":
                        loginSL.NavigateToHome(new HomeFragment());
                        break;
                }
            }
        }

        private void Service_OnResponseFailed(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            switch (e.RequestTag)
            {
                case LoginScreenConst.ServiceGetBasicInfo:
                    if (e.ResponseString.Equals(AndroidService<AppResponseObject>.ErrorNoConnection))
                    {
                        var dialog = BuildOfflineLoginErrorDialog();
                        dialog.Show();
                    }
                    break;
            }
        }

        private async void Service_OnResponseSuccess(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            switch (e.RequestTag)
            {
                case LoginScreenConst.ServiceGetBasicInfo:
                    HandleGetLoginInfoResponse((GetLoginInfoResponse)e.ResponseObject);
                    break;
                case LoginScreenConst.ServiceAuthenticate:
                    await HandleAuthenticationResponse((AuthenticationResponse)e.ResponseObject);
                    break;
            }
        }

        private void HandleGetLoginInfoResponse(GetLoginInfoResponse response)
        {
            bool isSucceess = response.Status.Equals(true);
            if (isSucceess)
            {
                loginSL.UpdateUserBasicInfo(response.Data.User);
                ShowPasswordLayout();
            }
            else if (response.ErrorCode.Equals(ServiceConstants.ErrorCodeUserNotExisted))
            {
                loginSL.ShowUsernameErrorDialog(response.ErrorMessage);
            }
        }

        private async Task HandleAuthenticationResponse(AuthenticationResponse response)
        {
            bool isSucceess = response.Status.Equals(true);
            if (isSucceess)
            {
                await loginSL.SaveAuthenticationKey(response.Data.Key);
                HideLoginPasswordLayout();
            }
            else if (response.ErrorCode.Equals(ServiceConstants.ErrorCodePasswordIncorrect))
            {
                loginSL.ShowPasswordIncorrectDialog(response.ErrorMessage);
            }
        }

        public IDialog BuildUsernameErrorDialog(string message)
        {
            var dialog = dialogBuilder.BuildSystemAlertDialog(LoginScreenConst.DialogUsernameError, "", message) as SystemAlertDialog;
            dialog.SetButton((int)DialogButtonType.Positive, LoginScreenConst.StringButtonSignInAsGuest);
            dialog.SetButton((int)DialogButtonType.Negative, LoginScreenConst.StringButtonRegister);
            dialog.OnButtonClicked += Dialog_OnButtonClicked;

            return dialog;
        }

        public IDialog BuildPasswordIncorrectDialog(string message)
        {
            var dialog = dialogBuilder.BuildSystemAlertDialog(LoginScreenConst.DialogPasswordError, "", message) as SystemAlertDialog;
            return dialog;
        }

        public IDialog BuildOfflineLoginErrorDialog()
        {
            var dialog = dialogBuilder.BuildSystemAlertDialog(LoginScreenConst.DialogOfflineLogin, "", LoginScreenConst.ErrorOfflineLogin) as SystemAlertDialog;
            dialog.SetButton((int)DialogButtonType.Positive, LoginScreenConst.StringButtonSignInAsGuest);
            dialog.SetButton((int)DialogButtonType.Negative, LoginScreenConst.StringButtonSettings);
            dialog.OnButtonClicked += Dialog_OnButtonClicked;

            return dialog;
        }

        private async void Dialog_OnButtonClicked(object sender, OnDialogButtonClickEventArgs e)
        {
            switch (e.DialogTag)
            {
                case LoginScreenConst.DialogUsernameError:
                    if (e.ButtonId == (int)DialogButtonType.Positive)
                    {
                        // Sign in as guest
                        await loginSL.HandleGuestSignIn(tfUsername.Input);
                        HideLoginUsernameLayout();
                    }
                    else if (e.ButtonId == (int)DialogButtonType.Negative)
                    {
                        // Register account
                    }
                    break;
                case LoginScreenConst.DialogOfflineLogin:
                    if (e.ButtonId == (int)DialogButtonType.Positive)
                    {
                        // Sign in as guest
                        await loginSL.HandleGuestSignIn(tfUsername.Input);
                        HideLoginUsernameLayout();
                    }
                    else if (e.ButtonId == (int)DialogButtonType.Negative)
                    {
                        // Go to device settings
                        Context.StartActivity(new Intent(Settings.ActionWifiSettings));
                    }
                    break;
            }
        }
    }
}

