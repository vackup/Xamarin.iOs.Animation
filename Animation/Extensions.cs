using System;
using CoreGraphics;
using UIKit;

namespace Animation
{
    public static class Extensions
    {
        public static void Rotate(this UIView view, bool isIn, bool fromLeft = true, double duration = 0.3, Action onFinished = null)
        {
            var minTransform = CGAffineTransform.MakeRotation((nfloat)((fromLeft ? -1 : 1) * DegreeToRadian(45)));
            var maxTransform = CGAffineTransform.MakeRotation((nfloat)0.0);
            
            view.Transform = isIn ? maxTransform : minTransform;
            UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => {
                    view.Transform = isIn ? minTransform : maxTransform;
                },
                onFinished
            );
        }

        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}