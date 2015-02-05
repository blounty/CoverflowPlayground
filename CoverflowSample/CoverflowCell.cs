
using System;
using System.Drawing;

using Foundation;
using UIKit;

using Haneke;
using CoverflowSample.Models;

namespace CoverflowSample
{
    public partial class CoverflowCell : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("CoverflowCell");

        public CoverflowCell(IntPtr handle)
            : base(handle)
        {
        }

        public void SetAlbum(Album album)
        {
            AlbumImageView.SetImage(new NSUrl(album.AlbumUrl));
        }
    }
}

