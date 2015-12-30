using Android.OS;
using Android.Views;
using App.Shared;
using Xamarin.Core;
using Xamarin.Core.Android;
using Android.Widget;
using System.Net.Http;
using ModernHttpClient;

namespace App.Android
{
    public class LoginFragment : AppFragment, ILoginScreen
    {
        private View LayoutLogin;
        private View LayoutLoginUsername;
        private View LayoutLoginPassword;

        private ImageView imgAvatar;
        private MaterialLabel lblCreateAccount;
        private MaterialLabel lblUsername;
        private MaterialButton btnNext;
        private MaterialButton btnSignIn;
        private MaterialButton btnBack;
        private SinglelineTextField tfUsername;
        private SinglelineTextField tfPassword;

        private ZoomOutAnimator LayoutAppearAnimator;
        private ResizeAnimator LayoutResizeAnimator;
        private FadeOutAnimator ContentAppearAnimator;
        private FadeInAnimator ContentDisappearAnimator;
        private FadeOutAnimator AvatarAppearAnimator;
        private FadeOutAnimator RegisterAppearAnimator;
        private FadeInAnimator RegisterDisappearAnimator;

        private LoginScreenLogic loginSL;
        private DialogBuilder dialogBuilder;
        private App.Shared.UserManager userManager;

        protected override int FragmentLayoutResId
        {
            get { return Resource.Layout.fragment_login; }
        }

        public App.Shared.UserManager UserManager
        {
            get { return userManager; }
        }

        protected override void BindControls(View rootView)
        {
            LayoutLogin = rootView.FindViewById(Resource.Id.layout_login);
            LayoutLoginUsername = rootView.FindViewById(Resource.Id.layout_login_username);
            LayoutLoginPassword = rootView.FindViewById(Resource.Id.layout_login_password);

            imgAvatar = rootView.FindViewById<ImageView>(Resource.Id.img_login_avatar);
            lblCreateAccount = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_login_create_account);
            lblUsername = rootView.FindViewById<MaterialLabel>(Resource.Id.lbl_login_username);
            btnNext = rootView.FindViewById<MaterialButton>(Resource.Id.btn_login_next);
            btnSignIn = rootView.FindViewById<MaterialButton>(Resource.Id.btn_login_sign_in);
            btnBack = rootView.FindViewById<MaterialButton>(Resource.Id.btn_login_back);

            tfUsername = rootView.FindViewById<SinglelineTextField>(Resource.Id.tf_login_username);
            tfPassword = rootView.FindViewById<SinglelineTextField>(Resource.Id.tf_login_password);
        }

        protected override void LoadData()
        {
            loginSL = new LoginScreenLogic(this);
            loginSL.InitializeScreen();

            dialogBuilder = new DialogBuilder(Context);

            var service = new AppService();
            service.OnResponseSuccess += Service_OnResponseSuccess;
            service.OnResponseFailed += Service_OnResponseFailed;
            userManager = new App.Shared.UserManager(service);
        }

        public IControl GetControlByTag(string tag)
        {
            switch (tag)
            {
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

            if (LayoutAppearAnimator == null)
            {
                LayoutAppearAnimator = new ZoomOutAnimator("LayoutAppearAnimator");
                LayoutAppearAnimator.SetAnimationView(LayoutLogin);
            }
            if (LayoutResizeAnimator == null)
            {
                LayoutResizeAnimator = new ResizeAnimator("LayoutResizeAnimator");
            }
            if (ContentAppearAnimator == null)
            {
                ContentAppearAnimator = new FadeOutAnimator("ContentAppearAnimator");
                ContentAppearAnimator.SetAnimationView(LayoutLoginUsername);
            }
            if (ContentDisappearAnimator == null)
            {
                ContentDisappearAnimator = new FadeInAnimator("ContentDisappearAnimator");
            }
            if (AvatarAppearAnimator == null)
            {
                AvatarAppearAnimator = new FadeOutAnimator("AvatarAppearAnimator");
                AvatarAppearAnimator.SetAnimationView(imgAvatar);
            }
            if (RegisterAppearAnimator == null)
            {
                RegisterAppearAnimator = new FadeOutAnimator("RegisterAppearAnimator");
                RegisterAppearAnimator.SetAnimationView(lblCreateAccount);
            }
            if (RegisterDisappearAnimator == null)
            {
                RegisterDisappearAnimator = new FadeInAnimator("RegisterDisappearAnimator");
            }

            LayoutAppearAnimator.OnAnimationFinished += OnAnimationFinished;
            AvatarAppearAnimator.OnAnimationStarting += OnAnimationStarting;
            ContentAppearAnimator.OnAnimationStarting += OnAnimationStarting;
            ContentDisappearAnimator.OnAnimationFinished += OnAnimationFinished;
            RegisterDisappearAnimator.OnAnimationFinished += OnAnimationFinished;
            RegisterAppearAnimator.OnAnimationStarting += OnAnimationStarting;

            LayoutAppearAnimator.Start();
        }

        public override void OnResume()
        {
            base.OnResume();

            btnNext.Click += OnButtonClicked;
            btnSignIn.Click += OnButtonClicked;
            btnBack.Click += OnButtonClicked;
        }

        public override void OnPause()
        {
            base.OnPause();

            LayoutAppearAnimator.OnAnimationFinished -= OnAnimationFinished;
            AvatarAppearAnimator.OnAnimationStarting -= OnAnimationStarting;
            ContentAppearAnimator.OnAnimationStarting -= OnAnimationStarting;
            ContentDisappearAnimator.OnAnimationFinished -= OnAnimationFinished;
            RegisterDisappearAnimator.OnAnimationFinished -= OnAnimationFinished;
            RegisterAppearAnimator.OnAnimationStarting -= OnAnimationStarting;

            btnNext.Click -= OnButtonClicked;
            btnSignIn.Click -= OnButtonClicked;
            btnBack.Click -= OnButtonClicked;
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
                    break;
                case Resource.Id.btn_login_back:
                    if (tfPassword.IsFocused)
                    {
                        tfPassword.ClearFocus();
                    }
                    ShowUsernameLayout();
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
                }
            }
        }

        private void Service_OnResponseFailed(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {

        }

        private void Service_OnResponseSuccess(object sender, ServiceResponseEventArgs<AppResponseObject> e)
        {
            switch (e.RequestTag)
            {
                case LoginScreenConst.ServiceGetBasicInfo:
                    var response = e.ResponseObject as GetLoginInfoResponse;
                    var isSucceess = response.Status.Equals(true);
                    if (isSucceess)
                    {
                        loginSL.UpdateUserBasicInfo(response.Data.User);
                        ShowPasswordLayout();
                    }
                    else if (response.ErrorCode.Equals(ServiceConstants.ErrorCodeUserNotExisted))
                    {
                        loginSL.ShowUserErrorDialog(response.ErrorMessage);
                    }
                    break;
            }
        }

        public IDialog BuildUsernameErrorDialog(string message)
        {
            var dialog = dialogBuilder.BuildSystemAlertDialog(LoginScreenConst.DialogUsernameError, "", message) as SystemAlertDialog;
            dialog.OnButtonClicked += Dialog_OnButtonClicked;

            return dialog;
        }

        private void Dialog_OnButtonClicked (object sender, OnDialogButtonClickEventArgs e)
        {
            
        }
    }
}

