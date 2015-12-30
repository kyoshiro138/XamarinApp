using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using System;
using Fragment = Android.Support.V4.App.Fragment;

namespace Xamarin.Core.Android
{
    public abstract class BaseDrawerActivity : BaseFragmentActivity
    {
        private DrawerLayout DrawerLayout;

        protected abstract int DrawerLayoutId { get; }

        protected abstract int LeftDrawerFragContainerId { get; }

        protected abstract int RightDrawerFragContainerId { get; }

        public event EventHandler<DrawerLayout.DrawerOpenedEventArgs> OnDrawerOpened;

        public event EventHandler<DrawerLayout.DrawerClosedEventArgs> OnDrawerClosed;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            DrawerLayout = FindViewById<DrawerLayout>(DrawerLayoutId);
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (DrawerLayout != null)
            {
                DrawerLayout.DrawerOpened += OnDrawerOpened;
                DrawerLayout.DrawerClosed += OnDrawerClosed;
            }
        }

        protected override void OnPause()
        {
            base.OnPause();

            if (DrawerLayout != null)
            {
                DrawerLayout.DrawerOpened -= OnDrawerOpened;
                DrawerLayout.DrawerClosed -= OnDrawerClosed;
            }
        }

        protected void SetLeftDrawerFragment(Fragment fragment)
        {
            var trasaction = SupportFragmentManager.BeginTransaction();
            trasaction.Replace(LeftDrawerFragContainerId, fragment, fragment.Class.SimpleName);
            trasaction.Commit();
        }

        protected void SetRightDrawerFragment(Fragment fragment)
        {
            var trasaction = SupportFragmentManager.BeginTransaction();
            trasaction.Replace(RightDrawerFragContainerId, fragment, fragment.Class.SimpleName);
            trasaction.Commit();
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && IsDrawersOpened())
            {
                DrawerLayout.CloseDrawers();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        #region Navigation Drawer methods

        public bool IsDrawerOpened(int drawerGravity)
        {
            if (DrawerLayout != null)
            {
                const int leftGravity = (int)GravityFlags.Left;
                const int rightGravity = (int)GravityFlags.Right;
                if (drawerGravity == leftGravity || drawerGravity == rightGravity)
                {
                    return DrawerLayout.IsDrawerOpen(drawerGravity);
                }
            }
            return false;
        }

        public bool IsDrawersOpened()
        {
            if (DrawerLayout != null)
            {
                const int leftGravity = (int)GravityFlags.Left;
                const int rightGravity = (int)GravityFlags.Right;
                return DrawerLayout.IsDrawerOpen(leftGravity) || DrawerLayout.IsDrawerOpen(rightGravity);
            }
            return false;
        }

        public void CloseDrawer(int drawerGravity)
        {
            if (DrawerLayout != null && IsDrawerOpened(drawerGravity))
            {
                DrawerLayout.CloseDrawer(drawerGravity);
            }
        }

        public void CloseDrawers()
        {
            if (DrawerLayout != null && IsDrawersOpened())
            {
                DrawerLayout.CloseDrawers();
            }
        }

        public void SetDrawerEnabled(bool enabled, int drawerGravity)
        {
            if (DrawerLayout != null)
            {
                int lockMode = enabled ? DrawerLayout.LockModeUnlocked : DrawerLayout.LockModeLockedClosed;
                DrawerLayout.SetDrawerLockMode(lockMode, drawerGravity);
            }
        }

        public void SetDrawersEnabled(bool enabled)
        {
            if (DrawerLayout != null)
            {
                int lockMode = enabled ? DrawerLayout.LockModeUnlocked : DrawerLayout.LockModeLockedClosed;
                DrawerLayout.SetDrawerLockMode(lockMode);
            }
        }

        #endregion
    }
}

