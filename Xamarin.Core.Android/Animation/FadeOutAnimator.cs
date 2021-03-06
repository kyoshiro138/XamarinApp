﻿using Android.Animation;
using Android.Views.Animations;

namespace Xamarin.Core.Android
{
    public class FadeOutAnimator : BaseAnimator
    {
        public FadeOutAnimator()
            : base()
        {
        }

        public FadeOutAnimator(string tag)
            : base(tag)
        {
        }

        protected override Animator InitAnimation()
        {
            ValueAnimator animator = ValueAnimator.OfFloat(1.0f, 0.0f);
            animator.SetInterpolator(new AccelerateInterpolator());

            return animator;
        }

        protected override void SubcribeAnimationEvents(Animator animation)
        {
            base.SubcribeAnimationEvents(animation);

            ValueAnimator valueAnimator = animation as ValueAnimator;
            if (valueAnimator != null)
            {
                valueAnimator.Update += OnAnimationUpdate;
            }
        }

        protected override void UnsubcribeAnimationEvents(Animator animation)
        {
            base.UnsubcribeAnimationEvents(animation);
            ValueAnimator valueAnimator = animation as ValueAnimator;
            if (valueAnimator != null)
            {
                valueAnimator.Update -= OnAnimationUpdate;
            }
        }

        private void OnAnimationUpdate(object sender, ValueAnimator.AnimatorUpdateEventArgs e)
        {
            float val = (float)e.Animation.AnimatedValue;
            AnimationView.Alpha = val;
        }
    }
}

