using System;
using Android.Content;
using Android.Util;
using Android.Views.Animations;
using Android.Widget;
using Android.Runtime;

namespace Xamarin.Core.Android
{
    public class AnimationGridView : SystemGridView, Animation.IAnimationListener
    {
        public event EventHandler<EventArgs> OnEnterAnimationStart;
        public event EventHandler<EventArgs> OnEnterAnimationEnd;
        public event EventHandler<EventArgs> OnExitAnimationStart;
        public event EventHandler<EventArgs> OnExitAnimationEnd;

        public int EnterAnimationId { get; private set; }

        public int ExitAnimationId { get; private set; }

        private int CurrentAnimationId { get; set; }

        public override IListAdapter Adapter
        {
            get { return base.Adapter; }
            set
            {
                base.Adapter = value;
                if (Adapter != null && Adapter.Count > 0)
                {
                    LayoutAnimation = loadLayoutAnimation(EnterAnimationId);
                    CurrentAnimationId = EnterAnimationId;
                    StartLayoutAnimation();
                }
                else
                {
                    LayoutAnimation = loadLayoutAnimation(ExitAnimationId);
                    CurrentAnimationId = ExitAnimationId;
                    StartLayoutAnimation();
                }
            }
        }

        public AnimationGridView(Context context)
            : base(context)
        {
        }

        public AnimationGridView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public AnimationGridView(Context context, IAttributeSet attrs, int defStyle)
            : base(context, attrs, defStyle)
        {
        }

        public AnimationGridView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        protected override void InitGridView()
        {
            LayoutAnimationListener = this;
            EnterAnimationId = Resource.Animation.abc_popup_enter;
            ExitAnimationId = Resource.Animation.abc_popup_exit;
        }

        public void SetAnimation(int enterAnimationId, int exitAnimationId)
        {
            EnterAnimationId = enterAnimationId;
            ExitAnimationId = exitAnimationId;
        }

        private GridLayoutAnimationController loadLayoutAnimation(int animationId)
        {
            Animation animation = AnimationUtils.LoadAnimation(Context, animationId);
            animation.FillEnabled = true;
            animation.FillAfter = true;

            GridLayoutAnimationController layoutAnimation = new GridLayoutAnimationController(animation);
            layoutAnimation.Order = DelayOrder.Normal;
            layoutAnimation.Delay = 0.2f;
            layoutAnimation.Direction = Direction.LeftToRight;
            layoutAnimation.Interpolator = new LinearInterpolator();
            return layoutAnimation;
        }

        public void OnAnimationEnd(Animation animation)
        {
            if (CurrentAnimationId == EnterAnimationId && OnEnterAnimationEnd != null)
            {
                OnEnterAnimationEnd.Invoke(animation, new EventArgs());
            }
            else if (CurrentAnimationId == ExitAnimationId && OnExitAnimationEnd != null)
            {
                OnExitAnimationEnd.Invoke(animation, new EventArgs());
            }
        }

        public void OnAnimationRepeat(Animation animation)
        {
            
        }

        public void OnAnimationStart(Animation animation)
        {
            if (CurrentAnimationId == EnterAnimationId && OnEnterAnimationStart != null)
            {
                OnEnterAnimationStart.Invoke(animation, new EventArgs());
            }
            else if (CurrentAnimationId == ExitAnimationId && OnExitAnimationEnd != null)
            {
                OnExitAnimationStart.Invoke(animation, new EventArgs());
            }
        }
    }
}

