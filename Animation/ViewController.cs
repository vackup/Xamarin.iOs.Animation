using System;
using CoreGraphics;
using UIKit;

namespace Animation
{
    public partial class ViewController : UIViewController
    {
        private bool _isIn = true;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var image = UIImage.FromBundle("add_btn");

            var shareButton = UIButton.FromType(UIButtonType.Custom);
            shareButton.SetImage(image, UIControlState.Normal);
            shareButton.SetImage(image, UIControlState.Highlighted);

            shareButton.Frame = new CGRect(
                this.View.Frame.Width / 2,
                this.View.Frame.Height / 2,
                image.Size.Width,
                image.Size.Height);

            shareButton.TouchUpInside += (sender, e) =>
            {
                var button = sender as UIButton;

                button.Rotate(_isIn, false);
                _isIn = !_isIn;
            };

            View.Add(shareButton);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}