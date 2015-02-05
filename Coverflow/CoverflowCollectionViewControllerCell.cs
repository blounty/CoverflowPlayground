
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Coverflow
{
    public class CoverflowCollectionViewControllerCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("CoverflowCollectionViewControllerCell");

        [Export("initWithFrame:")]
        public CoverflowCollectionViewControllerCell(RectangleF frame)
            : base(frame)
        {
            // TODO: add subviews to the ContentView, set various colors, etc.
            BackgroundColor = UIColor.Cyan;
        }
    }
}

