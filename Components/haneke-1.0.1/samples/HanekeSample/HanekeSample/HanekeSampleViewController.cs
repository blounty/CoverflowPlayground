using System;
using System.Drawing;

using Foundation;
using Haneke;

using UIKit;

namespace HanekeSample
{
    public partial class HanekeSampleViewController : UIViewController
    {
        public HanekeSampleViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            HNKCacheFormat format = (HNKCacheFormat)HNKCache.SharedCache().Formats["thumbnail"];
            if (format == null)
            {
                format = new HNKCacheFormat("thumbnail")
                    {
                        Size = new SizeF(320, 240),
                        ScaleMode = HNKScaleMode.AspectFill,
                        CompressionQuality = 0.5f,
                        DiskCapacity = 1 * 1024 * 1024,
                        PreloadPolicy = HNKPreloadPolicy.LastSession
                    };
            }


            TheImageView.SetCacheFormat(format);
            TheButton.SetBackgroundImage(new NSUrl("https://raw.githubusercontent.com/Haneke/Haneke/master/Assets/github-header.png"), UIControlState.Normal);
            TheImageView.SetImage(new NSUrl("https://raw.githubusercontent.com/Haneke/Haneke/master/Assets/github-header.png"));
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}

