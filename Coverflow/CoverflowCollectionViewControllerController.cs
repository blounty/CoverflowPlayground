
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Coverflow
{
    public class CoverflowCollectionViewControllerController : UICollectionViewController, IUICollectionViewDataSource, IUICollectionViewDelegate
    {

        public List<Album> Albums
        {
            get;
            set;
        }

        public CoverflowCollectionViewControllerController(UICollectionViewLayout layout)
            : base(layout)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();
			
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			
            Albums = CreateAlbums();
            // Register any custom UICollectionViewCell classes
            CollectionView.RegisterClassForCell(typeof(CoverflowCollectionViewControllerCell), CoverflowCollectionViewControllerCell.Key);
			
            // Note: If you use one of the Collection View Cell templates to create a new cell type,
            // you can register it using the RegisterNibForCell() method like this:
            //
            // CollectionView.RegisterNibForCell (MyCollectionViewCell.Nib, MyCollectionViewCell.Key);
        }

        public override int NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }

        public override int GetItemsCount(UICollectionView collectionView, int section)
        {
            return Albums.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell(CoverflowCollectionViewControllerCell.Key, indexPath) as CoverflowCollectionViewControllerCell;
			
            return cell;
        }
            
        List<Album> CreateAlbums()
        {
            var albums = new List<Album>();

            for (int i = 0; i < 10; i++)
            {
                albums.Add(new Album("https://pbs.twimg.com/profile_images/430208208964046848/hA5Bajc6.jpeg"));
            }

            return albums;
        }
    }
}

