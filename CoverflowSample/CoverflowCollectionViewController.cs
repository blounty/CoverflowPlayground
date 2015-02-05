using System;
using UIKit;
using System.Collections.Generic;
using CoverflowSample.Models;
using CoreGraphics;

namespace CoverflowSample
{
    public partial class CoverflowCollectionViewController
    : UICollectionViewController, IUICollectionViewDataSource, IUICollectionViewDelegateFlowLayout
    {
        nfloat smallestLength;
        List<Album> albums = new List<Album>();

        public CoverflowCollectionViewController(IntPtr handle)
            : base(handle)
        {
            CreateAlbums();
            CollectionView.WeakDataSource = this;
            CollectionView.WeakDelegate = this;
            CollectionView.PagingEnabled = true;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var parentSize = CollectionView.Frame.Size;
            smallestLength = parentSize.Width > parentSize.Height ? parentSize.Height : parentSize.Width;
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var cell = (CoverflowCell)CollectionView.DequeueReusableCell(CoverflowCell.Key, indexPath);

            var album = albums[indexPath.Row];

            cell.SetAlbum(album);

            return cell;
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return albums.Count;
        }

        [Foundation.Export("collectionView:layout:sizeForItemAtIndexPath:")]
        public CGSize GetSizeForItem(UIKit.UICollectionView collectionView, UIKit.UICollectionViewLayout layout, Foundation.NSIndexPath indexPath)
        {
            return new CGSize(smallestLength * .9f, smallestLength * .9f);
        }

        [Foundation.Export("collectionView:layout:minimumLineSpacingForSectionAtIndex:")]
        public nfloat GetMinimumLineSpacingForSection(UIKit.UICollectionView collectionView, UIKit.UICollectionViewLayout layout, System.nint section)
        {
            return smallestLength * .1f;
        }


        [Foundation.Export("collectionView:layout:minimumInteritemSpacingForSectionAtIndex:")]
        public nfloat GetMinimumInteritemSpacingForSection(UIKit.UICollectionView collectionView, UIKit.UICollectionViewLayout layout, System.nint section)
        {
            return 0;
        }

        [Foundation.Export("collectionView:layout:insetForSectionAtIndex:")]
        public UIKit.UIEdgeInsets GetInsetForSection(UIKit.UICollectionView collectionView, UIKit.UICollectionViewLayout layout, System.nint section)
        {
            var width = CollectionView.Frame.Width;
            return new UIEdgeInsets(0, width * .05f, 0, width * .05f);
        }

        void CreateAlbums()
        {
            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album("https://pbs.twimg.com/profile_images/430208208964046848/hA5Bajc6.jpeg"));
            }
        }
    }
}

