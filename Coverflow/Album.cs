
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Coverflow
{
	public class Album
	{
        public Album(string imageUrl)
        {
            ImageUrl = imageUrl;
        }

        public string ImageUrl
        {
            get;
            set;
        }
	}

}

