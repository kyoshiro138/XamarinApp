using System;
using Android.Animation;
using Android.Views;

namespace Xamarin.Core.Android
{
    public abstract class BaseAnimator : Java.Lang.Object
    {
        private const int DefaultDuration = 500;

        protected View AnimationView = null;

        protected Animator Animator { get; set; }

        public string Tag { get; protected set; }

        public long Duration
        {
            get { return Animator != null ? Animator.Duration : 0; }
            set
            {
                if (Animator != null)
                {
                    Animator.SetDuration(value);
                }
            }
        }

        public event EventHandler<AnimatorEventArgs> OnAnimationStarting;
        public event EventHandler<AnimatorEventArgs> OnAnimationStarted;
        public event EventHandler<AnimatorEventArgs> OnAnimationFinished;

        protected BaseAnimator()
            : this("ANIMATOR")
        {
        }

        protected BaseAnimator(string tag)
        {
            Tag = tag;
            Initialize();
        }

        private void Initialize()
        {
            Animator = InitAnimation();
            Duration = DefaultDuration;
        }

        protected abstract Animator InitAnimation();

        public virtual void SetAnimationView(View view)
        {
            if (Animator != null && Animator.IsRunning)
            {
                // Animation is running, not allow to change view
                return;
            }
            AnimationView = view;
        }

        public void Start()
        {
            if (AnimationView != null && Animator != null && !Animator.IsRunning)
            {
                SubcribeAnimationEvents(Animator);

                if (OnAnimationStarting != null)
                {
                    AnimatorEventArgs args = new AnimatorEventArgs(AnimationView);
                    OnAnimationStarting.Invoke(this, args);
                }
                Animator.Start();
            }
        }

        private void OnAnimationStart(object sender, EventArgs e)
        {
            if (OnAnimationStarted != null)
            {
                AnimatorEventArgs args = new AnimatorEventArgs(AnimationView);
                OnAnimationStarted.Invoke(this, args);
            }
        }

        private void OnAnimationEnd(object sender, EventArgs e)
        {
            if (OnAnimationFinished != null)
            {
                AnimatorEventArgs args = new AnimatorEventArgs(AnimationView);
                OnAnimationFinished.Invoke(this, args);
            }
            
            UnsubcribeAnimationEvents(Animator);
        }

        private void OnAnimationCancel(object sender, EventArgs e)
        {
            UnsubcribeAnimationEvents(Animator);
        }

        protected virtual void SubcribeAnimationEvents(Animator animation)
        {
            animation.AnimationStart += OnAnimationStart;
            animation.AnimationEnd += OnAnimationEnd;
            animation.AnimationCancel += OnAnimationCancel;
        }

        protected virtual void UnsubcribeAnimationEvents(Animator animation)
        {
            animation.AnimationStart -= OnAnimationStart;
            animation.AnimationEnd -= OnAnimationEnd;
            animation.AnimationCancel -= OnAnimationCancel;
        }
    }

    public class AnimatorEventArgs : EventArgs
    {
        public View AnimationView { get; private set; }

        public AnimatorEventArgs(View animationView)
        {
            AnimationView = animationView;
        }
    }
}

