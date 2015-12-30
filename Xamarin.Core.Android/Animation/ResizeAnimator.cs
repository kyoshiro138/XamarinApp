using Android.Animation;
using Android.Views.Animations;
using Android.Views;

namespace Xamarin.Core.Android
{
    public class ResizeAnimator : BaseAnimator
    {
        private int ViewWidth = 0;
        private int ViewHeight = 0;
        private int ViewResizedWidth = 0;
        private int ViewResizedHeight = 0;
        private float ViewYPos = 0;

        public ResizeAnimator()
            : base()
        {
        }

        public ResizeAnimator(string tag)
            : base(tag)
        {
        }

        protected override Animator InitAnimation()
        {
            ValueAnimator animator = ValueAnimator.OfInt(0, 100);
            animator.SetInterpolator(new AccelerateInterpolator());

            return animator;
        }

        public override void SetAnimationView(View view)
        {
            base.SetAnimationView(view);

            ViewWidth = view.MeasuredWidth;
            ViewHeight = view.MeasuredHeight;
            ViewYPos = view.GetY();
        }

        public void SetViewSizeAfterAnimated(int width, int height)
        {
            ViewResizedWidth = width;
            ViewResizedHeight = height;
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
            int val = (int)e.Animation.AnimatedValue;
            int resizingWidth = (ViewResizedWidth - ViewWidth) * val / 100;
            int resizingHeight = (ViewResizedHeight - ViewHeight) * val / 100;
            int width = ViewWidth + resizingWidth;
            int height = ViewHeight + resizingHeight;
            float y = ViewYPos + ((ViewHeight - height) / 2);

            ViewGroup.LayoutParams layoutParams = AnimationView.LayoutParameters;
            layoutParams.Width = width;
            layoutParams.Height = height;

            AnimationView.SetY(y);
            AnimationView.LayoutParameters = layoutParams;
        }
    }
}

