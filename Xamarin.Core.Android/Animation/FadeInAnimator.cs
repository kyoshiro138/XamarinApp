using Android.Animation;
using Android.Views.Animations;

namespace Xamarin.Core.Android
{
    public class FadeInAnimator : BaseAnimator
    {
        public FadeInAnimator()
            : base()
        {
        }

        public FadeInAnimator(string tag)
            : base(tag)
        {
        }

        protected override Animator InitAnimation()
        {
            ValueAnimator animator = ValueAnimator.OfFloat(0.0f, 1.0f);
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

